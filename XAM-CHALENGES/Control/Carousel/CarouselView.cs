using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XAMCHALENGES.Control.Carousel
{

    #region Carousel View

    /// <summary>
    /// This is the main view for Carousel control
    /// </summary>
    public class CarouselView : ContentView
    {
        #region Properties

        private IDictionary<string, CarouselModal> ItemsSelected
        {
            get;
            set;
        }

        public List<CarouselModal> SelectedItems
        {
            get;
            set;
        }

        List<CarouselModal> carouselmodel = new List<CarouselModal>();

        public List<CarouselModal> Source
        {
            get
            {
                return carouselmodel;
            }
            set
            {
                value = carouselmodel;
            }
        }

        public int ItemPerRow
        {
            get;
            set;
        } = 4;// default value


        #endregion


        #region Public declarations

        enum CarouselState { Edit, View };
        CarouselState CurrentState = CarouselState.View;  // Default in view mode
        Label lblStatus = new Label();

        #endregion


        public CarouselView()
        {
            ItemsSelected = new Dictionary<string, CarouselModal>();
        }

        public void SetResource(List<CarouselModal> Items)
        {
            Source = new List<CarouselModal>();
            Source.AddRange(Items);
            CreateCarousel();
        }



        void CreateCarousel()
        {
            ScrollView scrollView = new ScrollView();
            StackLayout stkWrapper = new StackLayout();
            StackLayout editStatusBar = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            Image imgEdit = new Image()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Source = "tick.ico",
                HeightRequest = WidthRequest = 50
            };
            editStatusBar.Children.Add(imgEdit);
            StackLayout actionStatusBar = new StackLayout();

            TapGestureRecognizer recognizer = new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 1
            };
            recognizer.Tapped += (sender, e) =>
            {
                if (CurrentState.Equals(CarouselState.Edit))
                    CurrentState = CarouselState.View;
                else
                    CurrentState = CarouselState.Edit;
                CreateCarousel();

            };
            imgEdit.GestureRecognizers.Add(recognizer);

            editStatusBar.Children.Add(imgEdit);

            stkWrapper.Children.Add(editStatusBar);

            Grid grdMain = new Grid()
            {
               // Margin = 20,RowSpacing=5
               // HeightRequest=100
            };
            int index = 0;
            for (int i = 0; i < Source.Count; i++)
            {
                int originalivalue = i;
                ItemPerRow = ItemPerRow >= Source.Count ? Source.Count : ItemPerRow;
                for (int j = 0; j < ItemPerRow; j++)
                {
                    if (Source.Count > index)
                    {
                            grdMain.RowDefinitions.Add(new RowDefinition()
                            {
                                Height = 50
                              //  Height=new GridLength(1,GridUnitType.Auto)
                            });
                        RelativeLayout rtlThumbnailContent = new RelativeLayout()
                        {
                            Margin = 0,
                            VerticalOptions = HorizontalOptions = LayoutOptions.FillAndExpand
                          

                        };
                        Image ThumbNail = new Image()
                        {
                            Source = Source[i].FilePath,
                            Aspect = Aspect.AspectFit,
                            ClassId = Source[i].Id
                        };


                        rtlThumbnailContent.Children.Add(ThumbNail, Constraint.RelativeToParent((parent) =>
                        {
                            return parent.X*0;
                        }), Constraint.RelativeToParent((parent) =>
                        {
                            return parent.Y*0;
                        }), Constraint.RelativeToParent((parent) =>
                        {
                            return parent.Width;
                        }), Constraint.RelativeToParent((parent) =>
                        {
                            return parent.Height;
                        }));

                        CustomImage imgSelect = new CustomImage()
                        {
                            ID = System.IO.Path.GetFileName(Source[i].FilePath),
                            IsVisible = CurrentState.Equals(CarouselState.Edit)
                            //WidthRequest= HeightRequest=10
                        };

                        rtlThumbnailContent.Children.Add(imgSelect, Constraint.RelativeToView(ThumbNail, (parent, view) =>
                        {
                            return view.Width * .8;
                        }), Constraint.RelativeToView(ThumbNail, (parent, view) =>
                        {
                            return view.Height * .0;
                        })
                        //                                 , Constraint.RelativeToView(ThumbNail, (parent, view) =>
                        //{
                        //    return view.Height * .4;
                        //}), Constraint.RelativeToView(ThumbNail, (parent, view) =>
                        //{
                        //    return view.Height * .4;
                        //})
                                                        );
                        var sdf = new StackLayout();
                        sdf.Children.Add(rtlThumbnailContent);


                        TapGestureRecognizer imgtap = new TapGestureRecognizer();

                        imgtap.Tapped += Imgtap_Tapped;

                        imgSelect.GestureRecognizers.Add(imgtap);


                        TapGestureRecognizer imgThumbNailtap = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };
                        imgThumbNailtap.Tapped += async (sender, e) => {
                            if (CurrentState.Equals(CarouselState.View))
                            {
                                Image img = sender as Image;
                                CarouselModal modal = Source.FirstOrDefault(ec => ec.Id == img.ClassId);
                                await Navigation.PushModalAsync(new MediaPlayerPage(modal));
                            }
                            else
                            {
                                Imgtap_Tapped(imgSelect, e);
                            }
                        };
                        ThumbNail.GestureRecognizers.Add(imgThumbNailtap);

                        i++;
                        grdMain.Children.Add(rtlThumbnailContent, j, originalivalue);
                    }
                }
            }

            StackLayout stkStatusbar = new StackLayout()
            {
                BackgroundColor = Color.Gray
            };

            lblStatus.Text = $"{SelectedItems?.Count} item(s) selected.";
            stkStatusbar.Children.Add(lblStatus);

            stkWrapper.Children.Add(grdMain);
            stkWrapper.Children.Add(stkStatusbar);
            scrollView.Content = stkWrapper;
            this.Content = scrollView;
        }

        void Imgtap_Tapped(object sender, EventArgs e)
        {
            CustomImage imgtick = sender as CustomImage;
            imgtick.isSelected = !imgtick.isSelected;
            imgtick.Source = imgtick.isSelected ? "tick.ico" : "uncheck";
            if (imgtick.isSelected)
                ItemsSelected.Add(imgtick.ID, Source.Where(item => item.Id.Equals(imgtick.ID)).FirstOrDefault());
            else
                ItemsSelected.Remove(imgtick.ID);
            SelectedItems = ItemsSelected.Select(x => x.Value).ToList();
            lblStatus.Text = $"{SelectedItems.Count} item(s) selected.";
            var rtl = imgtick.Parent as RelativeLayout;
            Image imgThumbNail = rtl.Children[0] as Image;
        }
    }

    /// <summary>
    /// Model class for Carousel control
    /// </summary>
    public class CarouselModal
    {
        public string Id
        {
            get
            {
                return System.IO.Path.GetFileName(FilePath);
            }
            set
            {
                value = System.IO.Path.GetFileName(FilePath);
            }
        }

        public string FilePath
        {
            get;
            set;
        }
        public string Thumbnail
        {
            get;
            set;
        }
        public string Label
        {
            get;
            set;
        }
    }


    #endregion

    #region Media view page

    /// <summary>
    /// This is the page to show medias based on the attachment type
    /// </summary>
    public class MediaPlayerPage : ContentPage
    {
      
        
        public MediaPlayerPage(CarouselModal carouselModal)
        {
            
            string flag = "image";
            switch (flag)
            {
                case "image":
                    {
                        this.Content = new PictureView(carouselModal);
                    };
                    break;

                default:
                    break;
            }
        }
    }


    /// <summary>
    /// This holds functionalities about image view
    /// </summary>
    public class PictureView:ContentView
    {
        public PictureView(CarouselModal carouselModal)
        {
             
            StackLayout stkContent = new StackLayout();
            Image img = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Source =carouselModal.FilePath
            };

            StackLayout stkControls = new StackLayout()
            {
                BackgroundColor = Color.FromHex("#80000000")
            };
            Button btnClose = new Button()
            {
                Text = "Click to close"
            };
            btnClose.Clicked += (sender, e) =>
            {
                this.Navigation.PopModalAsync();
            };
            stkControls.Children.Add(btnClose);
            stkContent.Children.Add(img);
            stkContent.Children.Add(stkControls);
            this.Content = stkContent;
        }
    }

    #endregion

}