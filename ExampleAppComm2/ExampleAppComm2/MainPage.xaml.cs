
using System;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

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


            //textBlock.Text = "This is an example";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String con = "default";

            var uri = new Uri("ms-appx:///Assets/logos/logo.png");

            try {
                var arguments = e.Parameter as ProtocolActivatedEventArgs;
                var set = arguments.Data as ValueSet;
                con = set.ElementAt(0).Value.ToString();
                //textBlock.Text = set.ElementAt(0).Value.ToString();
                base.OnNavigatedTo(e);
            }
            catch(Exception ex)
            {

            }

            switch (con)
            {
                case "Comiccon":
                    uri = new Uri("ms-appx:///Assets/logos/dcc.png");
                    break;
                case "MGC Experience":
                    uri = new Uri("ms-appx:///Assets/logos/mgc.jpg");
                    break;
                case "Tsunacon":
                    uri = new Uri("ms-appx:///Assets/logos/tsunacon.png");
                    break;
                case "Nishicon":
                    uri = new Uri("ms-appx:///Assets/logos/nishicon.png");
                    break;
                case "Tomocon":
                    uri = new Uri("ms-appx:///Assets/logos/tomocon.jpg");
                    break;
                case "Animecon":
                    uri = new Uri("ms-appx:///Assets/logos/animecon.jpg");
                    break;
            }

            var bitmap = new BitmapImage(uri);
            image.Source = bitmap;
            textBlock.Text = getText(con);
        }



        private String getText(string con)
        {
            string text = "";
            string filepath = @"Assets/info/"+con+".txt";

            string[] myLines = File.ReadAllLines(filepath);
            
            for(int i = 0; i<myLines.Length; i++)
            {
                text += "\n" + myLines[i];
            }

            return text;
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
