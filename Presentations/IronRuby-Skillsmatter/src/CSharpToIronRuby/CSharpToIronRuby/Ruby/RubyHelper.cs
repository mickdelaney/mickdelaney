using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using IronRuby.Builtins;
using IronRuby.Runtime.Calls;
using System.IO;

namespace CSharpToIronRuby
{
    public class RubyHelper
    {
        public ScriptEngine Engine = IronRuby.Ruby.CreateEngine();
        private ScriptScope Scope; 

        public RubyHelper()
        {
            Scope = Engine.CreateScope();

            Engine.SetSearchPaths
            LoadRubyFiles();
        }

        public void LoadRubyFiles()
        {
            Directory.GetFiles(Utils.ExpandPath("Ruby")).ToList().ForEach(LoadFileInEngine);
            Directory.GetFiles(Utils.ExpandPath("Specs")).ToList().ForEach(LoadFileInEngine);
        }

        public void LoadFileInEngine(string fileName)
        {
            string sourceCode = Utils.GetStringFromFile(fileName);
            ScriptSource source = Engine.CreateScriptSourceFromString(sourceCode, SourceCodeKind.File);
            RubyClass rubyClass = source.Execute(Scope) as RubyClass;
        }


        public void RunCode()
        {
            ScriptScope scope = Engine.CreateScope();
            //scope.SetVariable("txt", "IronRuby is awesome!");
            //var upperMethod = engine.GetVariable(scope, "upper");
            RubyClass personClass = Engine.Runtime.Globals.GetVariable("Rule") as RubyClass;
            RubyMemberInfo method = personClass.GetMethod("execute");
            object ruleObject = Engine.Operations.CreateInstance(personClass);
            dynamic rule = ruleObject;

            Console.WriteLine(rule.execute());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rubySource"></param>
        /// <returns></returns>
        public IRule CreateRule(string rubySource)
        {
            string source = String.Format("Proc.new {{ |e| {0} }}", rubySource);
            ScriptSource scriptSource = Engine.CreateScriptSourceFromString(source);               
            var proc = (Proc)scriptSource.Execute();

            Predicate<Order> predicate = p => (bool)proc.Call(p);
            return new RubyRule(predicate);
        }

        public dynamic CreateInstance(string className)
        {
            RubyClass rubyClass = Scope.GetVariable(className) as RubyClass;
            return Engine.Operations.CreateInstance(rubyClass) as dynamic;
        }

    }
}
