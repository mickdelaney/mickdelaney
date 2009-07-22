using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpToIronRuby
{
    public class RuleEngine
    {
        public IRuleStore _store;

        public RuleEngine(IRuleStore store)
        {
            _store = store;
        }

        public IResult ExecuteRulesForOrder(Order o)
        {
            Result result = new Result();
            foreach (IRule rule in _store.GetRules())
            {
                

            }

            return result;
        }

    }
}