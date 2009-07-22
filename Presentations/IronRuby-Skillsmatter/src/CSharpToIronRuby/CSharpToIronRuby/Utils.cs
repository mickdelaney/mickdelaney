using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CSharpToIronRuby
{
    public class Utils
    {
        public static string GetStringFromFile(string fileName)
        {
            var reader = File.OpenText(fileName);
            string sourceCode = reader.ReadToEnd();
            reader.Close();
            return sourceCode;
        }
        public static string ExpandPath(string relativePath)
        {
            string binDebug = Path.GetDirectoryName(typeof(RubyHelper).Assembly.Location);
            return Path.Combine(binDebug, relativePath);
        }

    }
}
