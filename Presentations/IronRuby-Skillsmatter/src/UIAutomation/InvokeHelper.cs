using System.Windows.Automation.Provider;

namespace UIAutomation
{
    public class InvokeHelper
    {
        private readonly IInvokeProvider _provider;

        public InvokeHelper(IInvokeProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Invoke()
        {
            _provider.Invoke();
        }
    }
}
