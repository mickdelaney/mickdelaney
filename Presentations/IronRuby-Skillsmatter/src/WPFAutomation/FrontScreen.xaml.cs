using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace WPFAutomation
{
    /// <summary>
    /// Interaction logic for FrontScreen.xaml
    /// </summary>
    public partial class FrontScreen
    {
        public FrontScreen()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //var windowPeer = new WindowAutomationPeer(this);
            //var saveButton = this.FindName("saveButton") as Button;
            //var saveButtonPeer = new ButtonAutomationPeer(saveButton);

            //var autoMateButton = this.FindName("autoMateButton") as Button;
            //var autoMateButtonPeer = new ButtonAutomationPeer(autoMateButton);

            //((IInvokeProvider)autoMateButtonPeer).Invoke();

            double price = Int32.Parse(priceText.Text);
            double percentage = Int32.Parse(percentageText.Text);
            costLabel.Content = (price*(percentage/100)).ToString();

        }

        private void autoMateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("u clicked me!!");
        }
    }
}
