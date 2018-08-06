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
                
           
        }
        public bool isSelected
        {
            get;
            set;
        } = false;

        public string ID
        {
            get;
            set;
        }
    }
}
