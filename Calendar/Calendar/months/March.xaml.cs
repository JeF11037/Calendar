using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class March : ContentPage
    {
        Random rnd = new Random();
        public March()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Image img = new Image();
            img.Source = "spring.png";
            img.Opacity = 1;
            img.Scale = 3;
            stack.Children.Add(img);
            int tempX = Convert.ToInt32(DeviceDisplay.MainDisplayInfo.Width)/2;
            await Task.WhenAll(
                img.TranslateTo(0, -2000, 1),
                img.TranslateTo(0, 500, 6000),
                img.FadeTo(1, 4000)
                );
        }
    }
}