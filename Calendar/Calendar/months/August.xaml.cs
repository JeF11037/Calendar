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
    public partial class August : ContentPage
    {
        Random rnd = new Random();
        string[] images = new string[3] { "fresh_leaves1.png", "fresh_leaves2.png", "fresh_leaves3.png" };
        public August()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Appears();
        }

        private async void Appears()
        {
            mainImg.Opacity = 0;
            await mainImg.FadeTo(1, 2000);
        }

        private async void ImageAnimation()
        {
            Image img = new Image();
            img.Source = images[rnd.Next(0, 3)];
            img.Opacity = 0;
            img.Scale = 3;
            stack.Children.Add(img);
            int tempX = Convert.ToInt32(DeviceDisplay.MainDisplayInfo.Width) / 2;
            await img.TranslateTo(0, 0 - DeviceDisplay.MainDisplayInfo.Height / 2);
            await Task.WhenAll(
                img.TranslateTo(0, 500, 6000, Easing.Linear),
                img.FadeTo(1, 4000)
                );
            stack.Children.Remove(img);
        }

        private async void CalendarAnimation(bool inverse)
        {
            if (inverse)
            {
                mainImg.Opacity = 1;
                await mainImg.FadeTo(0, 2000);
            }
            else
            {
                mainImg.Opacity = 0;
                await mainImg.FadeTo(1, 2000);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            CalendarAnimation(true);
            ImageAnimation();
            CalendarAnimation(false);
        }
    }
}