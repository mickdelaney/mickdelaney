using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpToIronRuby
{
    public interface IResult
    {
        bool IsValid { get; set; }
        List<string> Messages { get; set; }
    }

    public class Result : IResult
    {
        public List<string> Messages { get; set; }
        public bool IsValid { get; set; }
    }

}
