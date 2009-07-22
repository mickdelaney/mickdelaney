using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpToIronRuby
{
    public interface IRule
    {
        bool Execute(Order order);
    }
}
