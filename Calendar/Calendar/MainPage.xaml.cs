using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace Calendar
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            AskAboutPage();
        }

        async void AskAboutPage()
        {
            string page = await DisplayActionSheet("What page do you want to see ?", "Cancel", null, "Spring", "Summer", "Autumn", "Winter");
            switch (page)
            {
                default:
                    break;
                case "Spring":
                    CurrentPage = Children[0];
                    break;
                case "Summer":
                    CurrentPage = Children[1];
                    break;
                case "Autumn":
                    CurrentPage = Children[2];
                    break;
                case "Winter":
                    CurrentPage = Children[3];
                    break;
            }
        }
    }
}
