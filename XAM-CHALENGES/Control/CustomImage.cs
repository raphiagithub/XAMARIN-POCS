using System;
using Xamarin.Forms;

namespace XAMCHALENGES.Control
{
	public class CustomImage:Image
    {
        public CustomImage()
        {
            Aspect = Aspect.Fill;
            Source = "uncheck";
            HeightRequest = 80;
            WidthRequest = 80;

            TapGestureRecognizer imgtap = new TapGestureRecognizer();
            imgtap.Tapped += (sender, e) => {
                CustomImage imgtick = sender as CustomImage;
                imgtick.isSelected = !imgtick.isSelected;
                imgtick.Source = imgtick.isSelected ? "tick.ico" : "uncheck";

                var rtl = imgtick.Parent as RelativeLayout;
                Image imgThumbNail = rtl.Children[0] as Image;
                //imgThumbNail.Aspect = imgtick.isSelected ? Aspect.AspectFit : Aspect.AspectFill;
            };
            this.GestureRecognizers.Add(imgtap);
        }
        public bool isSelected
        {
            get;
            set;
        } = false;
    }
}
