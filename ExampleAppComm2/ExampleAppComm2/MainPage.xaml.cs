
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExampleAppComm2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            textBlock.Text = "This is an example";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try {
                var arguments = e.Parameter as ProtocolActivatedEventArgs;
                var set = arguments.Data as ValueSet;

                textBlock.Text = set.ElementAt(0).Value.ToString();
                base.OnNavigatedTo(e);
            }
            catch(Exception ex)
            {

            }
        }

 

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
