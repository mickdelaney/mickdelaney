using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;
using IronRuby.Builtins;

namespace CSharpToIronRuby
{
    public class RubyRule : IRule
    {
        public string _name;
        public string _rule;

        Predicate<Order> _predicate;

        public RubyRule(Predicate<Order> predicate)
        {
            _predicate = predicate;
        }

        public RubyRule(string name, string rule)
        {
            _name = name;
            _rule = rule;

        }

        public bool Execute(Order order)
        {
            if (_predicate == null)
            {
                buildPredicate();
            }

            return _predicate.Invoke(order);
        }

        private void buildPredicate()
        {
            RubyHelper helper = new RubyHelper();
            var scriptSource = helper.Engine.CreateScriptSourceFromString(_rule);
            var proc = (Proc)scriptSource.Execute();
            _predicate = p => (bool)proc.Call(p);
        }
    }
}
