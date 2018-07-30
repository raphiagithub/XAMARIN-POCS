using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XAMCHALENGES.Views
{
    public partial class GallaryView : ContentPage
    {
        public GallaryView()
        {
            InitializeComponent();
            this.BindingContext = new GallaryViewModel();
        }

      

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var image= sender as Image;
            image.Source = "uncheck.png";
           // throw new NotImplementedException();
        }
    }

    public class GallaryViewModel
    {
        public List<GallaryModel> Source
        {
            get;
            set;
        }
        public GallaryViewModel()
        {
            Source = new List<GallaryModel>();
            Source.Add(new GallaryModel()
            {
                ThumbnailSource = "video.png"
            });
            Source.Add(new GallaryModel()
            {
                ThumbnailSource = "video.png"
            });
        }
    }

    public class GallaryModel
    {
        public string ThumbnailSource
        {
            get;
            set;
        }
    }
}
