using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XAMCHALENGES.Control;

namespace XAMCHALENGES.Pages
{
    public partial class Carouselview : ContentView
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
        } = 2;// default value


        #endregion


        #region Public declarations

        enum CarouselState { Edit, View };
        CarouselState CurrentState=CarouselState.View;  // Default in view mode
        Label lblStatus = new Label();

        #endregion


        public Carouselview()
        {
              
            
            ItemsSelected = new Dictionary<string, CarouselModal>();
        }

        public void SetResource(List<CarouselModal> Items)
        {
             Source = new List<CarouselModal>();
             Source.AddRange(Items);
            test();
        }

      
        private void OnTapGestureRecognizerTapped(object sender, EventArgs eventArgs)
        {
            CustomImage imgtick = sender as CustomImage;
            imgtick.isSelected = !imgtick.isSelected;
            imgtick.Source = imgtick.isSelected ? "tick.ico" : "uncheck";

            var rtl = imgtick.Parent as RelativeLayout;
            Image imgThumbNail = rtl.Children[0] as Image;
            imgThumbNail.Aspect = imgtick.isSelected ? Aspect.AspectFit : Aspect.AspectFill;
        }
        
  

        void test()
        {
            ScrollView scrollView = new ScrollView();
            StackLayout stkWrapper = new StackLayout();
            StackLayout editStatusBar = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            //Image imgEdit = new Image()
            //{
            //    HorizontalOptions = LayoutOptions.EndAndExpand,
            //    Source = "tick.ico",
            //    HeightRequest = WidthRequest = 50
            //};
            //editStatusBar.Children.Add(imgEdit);
            //StackLayout actionStatusBar = new StackLayout();

            Button btnEdit = new Button()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Text = "Edit"
            };
            btnEdit.Clicked+=(sender, e) => {
                CurrentState = CarouselState.Edit;
                test();
            };
            editStatusBar.Children.Add(btnEdit);

            stkWrapper.Children.Add(editStatusBar);
            
            Grid grdMain = new Grid()
            {
                Margin = 20
            };
            for (int i = 0; i < Source.Count; i++)
            {
                int originalivalue = i;
                ItemPerRow = ItemPerRow >= Source.Count ? Source.Count : ItemPerRow;
                for (int j = 0; j < ItemPerRow; j++)
                {
                    if (Source.Count > i)
                    {
                        grdMain.RowDefinitions.Add(new RowDefinition()
                        {
                            Height=100 
                        });
                        RelativeLayout rtlThumbnailContent = new RelativeLayout()
                        {
                            Margin = 0,
                            VerticalOptions= HorizontalOptions = LayoutOptions.FillAndExpand,
                            HeightRequest=100
                        };
                        Image ThumbNail = new Image()
                        {
                            Source = Source[i].FilePath,
                            BackgroundColor = Color.Blue,
                            Aspect = Aspect.AspectFit,
                            HeightRequest=100

                        };

                        rtlThumbnailContent.Children.Add(ThumbNail, Constraint.RelativeToParent((parent) =>
                       {
                           return parent.X;
                       }), Constraint.RelativeToParent((parent) =>
                       {
                           return parent.Y;
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
                        };

                        rtlThumbnailContent.Children.Add(imgSelect, Constraint.RelativeToView(ThumbNail, (parent, view) =>
                       {
                           return view.Width * .9;
                       }), Constraint.RelativeToView(ThumbNail, (parent, view) =>
                         {
                             return view.Height * .1;
                         }), Constraint.RelativeToView(ThumbNail, (parent, view) =>
                     {
                         return view.Height * .4;
                     }), Constraint.RelativeToView(ThumbNail, (parent, view) =>
                     {
                         return view.Height * .4;
                     }));
                        var sdf = new StackLayout();
                        sdf.Children.Add(rtlThumbnailContent);


                        TapGestureRecognizer imgtap = new TapGestureRecognizer();
                        imgtap.Tapped += (sender, e) =>
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
                        };
                        imgSelect.GestureRecognizers.Add(imgtap);
                        i++;
                        grdMain.Children.Add(sdf, j, originalivalue);
                    }
                }
            }

            StackLayout stkStatusbar = new StackLayout()
            {
                BackgroundColor=Color.Gray
            };

            lblStatus.Text = $"{SelectedItems?.Count} item(s) selected.";
            stkStatusbar.Children.Add(lblStatus);

            stkWrapper.Children.Add(grdMain);
            stkWrapper.Children.Add(stkStatusbar);
            scrollView.Content = stkWrapper;
            this.Content = grdMain;
        }
    }

    public class CarouselModal
    {
        public string Id
        {
            get
            {
                return System.IO.Path.GetFileName(FilePath);
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
}
