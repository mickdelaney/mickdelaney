using System.Collections.Generic;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using NUnit.Framework;
using WPFAutomation;

namespace UIAutomation
{
    [TestFixture]
    public class CallWindowTest
    {
        [Test]
        public void CanAccessSaveButton()
        {
            var screen = new FrontScreen();
            var windowPeer = new WindowAutomationPeer(screen);
            var children = windowPeer.GetChildren();
            var peer = children[1] as IInvokeProvider;
            peer.Invoke();


            Assert.That(children != null);
            
        }

    }
}
