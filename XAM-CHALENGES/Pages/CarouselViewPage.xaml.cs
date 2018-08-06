using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XAMCHALENGES.Pages
{
    public partial class CarouselViewPage : ContentPage
    {
        public CarouselViewPage()
        {
            InitializeComponent();
            // this.Content = new Carouselview();

            List<CarouselModal> model = new List<CarouselModal>();

            model.Add(new CarouselModal()
            {
                FilePath = "https://static.timesofisrael.com/www/uploads/2016/05/%D7%90%D7%9D%D7%A6.jpg"
            });
            model.Add(new CarouselModal()
            {
                FilePath = "https://vsd.img.pmdstatic.net/pad/http.3A.2F.2Fprd-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2Fvsd.2Fvar.2Fvsd.2Fstorage.2Fimages.2Fmedia.2Fmulti-upload.2F09-mai-2016.2Ftom-jerry-13727.2F88960-1-fre-FR.2Ftom-jerry.2Ejpg/460x340/quality/80/vsd.jpg"
            });
            model.Add(new CarouselModal()
            {
                FilePath = "https://i.kym-cdn.com/photos/images/original/001/149/102/6f3.png"
            });
            model.Add(new CarouselModal()
            {
                FilePath = "https://i.ytimg.com/vi/5GmvUZlKWGM/maxresdefault.jpg"
            }); 
            model.Add(new CarouselModal()
            {
                FilePath = "http://www.wallpapers13.com/wp-content/uploads/2016/11/Tom-And-Jerry-Go-Back-in-Time-HD-Wallpaper-1920x1200-915x515.jpg"
            }); 
            model.Add(new CarouselModal()
            {
                FilePath = "https://i.ytimg.com/vi/UxY_CR_Al1c/hqdefault.jpg"
            }); 
            model.Add(new CarouselModal()
            {
                FilePath = "https://cfvod.kaltura.com/p/1836881/sp/183688100/thumbnail/entry_id/0_3a095y5f/version/100000/width/600/height/400"
            }); 
            model.Add(new CarouselModal()
            {
                FilePath = "https://i.ytimg.com/vi/Kua-yVYY41Q/maxresdefault.jpg"
            }); 
            model.Add(new CarouselModal()
            {
                FilePath = "https://lonelytypewriter.files.wordpress.com/2013/09/screen-shot-2013-09-22-at-12-43-31-am.png"
            }); 
            model.Add(new CarouselModal()
            {
                FilePath = "https://d1u4oo4rb13yy8.cloudfront.net/article/84479-zdqlxovilm-1521023254.jpeg"
            });   model.Add(new CarouselModal()
            {
                FilePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHNSsL9RW0O0xbDT7dRy1w1jMWy9zE899-0-4ruvdW30-Y_lgfpg"
            });   model.Add(new CarouselModal()
            {
                FilePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQHHG_TjrU8X0h65kWIAzJPyhr1FTJve_l6OBD1HPZb_FxZwmdTA"
            }); 
            model.Add(new CarouselModal()
            {
                FilePath = "http://deskbg.com/s3/wpp/2/2735/shocked-tom-and-jerry-desktop-background.jpg"
            });   model.Add(new CarouselModal()
            {
                FilePath = "http://www.heroesarcade.com/games/icons/tom-and-jerry-math-game.jpg"
            }); 
            model.Add(new CarouselModal()
            {
                FilePath = "https://snailtaletv.files.wordpress.com/2017/11/tom-and-jerry-episode-78-two-little-indians-1953-part-1-best-cartoons-for-kids.jpg?"
            }); 



            cv.SetResource(model);

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("aelrt",(cv.SelectedItems.Count + " items  are selected"), "ok");
        }
    }
}
