using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IronRuby.Builtins;
using IronRuby.Runtime.Calls;
using Microsoft.Scripting.Hosting;

namespace CSharpToIronRuby
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class RulesEditor : Window
    {
        RubyHelper helper = new RubyHelper();
        dynamic rulesEngine; 
        
        public RulesEditor()
        {
            InitializeComponent();
            rulesEngine = helper.CreateInstance("RulesEngine");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //string dbPath = RubyHelper.ExpandPath("Rules.mdf");
            //var db = new RulesDataContext(dbPath);
            //Rule rule = new Rule();
            //rule.Name = nameText.Text;
            //rule.Rule1 = ruleText.Text;
            //db.Rules.InsertOnSubmit(rule);
            //db.SubmitChanges();

            List<dynamic> rules = new List<dynamic>();
            dynamic rule = helper.CreateInstance("Rule");
            rule.set_name(nameText.Text);
                   
            string code = string.Format("lambda {{|order| {0} }}", ruleText.Text);
            ScriptSource scriptSource = helper.Engine.CreateScriptSourceFromString(code);               
            var proc = (Proc)scriptSource.Execute();

            rule.set_code(proc.ToLambda());
            rules.Add(rule);

            rulesEngine.set_rules(rules);

            rulesEngine.build_rules();
            rulesEngine.validate_order(new Order { Price = 9 }); 
            

        }
    }
}
