using System.Collections.Generic;

namespace Domain
{
    public class Calculator
    {
        private List<int> args = new List<int>();

        public void Push(int n)
        {
            args.Add(n);
        }

        public int Add()
        {
            int result = 0;
            foreach (int n in args)
            {
                result += n;
            }
            return result;
        }
    }
}
