using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpToIronRuby
{
    public interface IRuleStore
    {
        List<IRule> GetRules();
    }
}
