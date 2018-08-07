using System;
using Xamarin.Forms;

namespace XAMCHALENGES.CustomClasses
{
    public class CustomImage:Image
    {
        public string State
        {
            get;
            set;
        }
        public CustomImage()
        {
            this.Source = "uncheck.png";

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.NumberOfTapsRequired = 1;
            this.GestureRecognizers.Add(tapGestureRecognizer);
            tapGestureRecognizer.Tapped+=TapGestureRecognizer_Tapped;
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var image = sender as CustomImage;
            image.Source = "tick.ico";
        }
    }
}
