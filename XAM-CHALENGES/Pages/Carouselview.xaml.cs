using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XAMCHALENGES.Control;

namespace XAMCHALENGES.Pages
{
    public partial class Carouselview : ContentView
    {
        public Carouselview()
        {
            //InitializeComponent();
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
            Grid grdMain = new Grid()
            {
                Margin = 20
            };
            grdMain.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(.5, GridUnitType.Star) });
            grdMain.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(.5, GridUnitType.Star) });

            for (int i = 0; i < 10; i++)
            {


                grdMain.RowDefinitions.Add(new RowDefinition() { Height = 300 });






                RelativeLayout rtlThumbnailContent = new RelativeLayout() { Margin = 15 };
                Image ThumbNail = new Image()
                {
                    Source = "video",

                    VerticalOptions = HorizontalOptions = LayoutOptions.FillAndExpand
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



                /*  
             <RelativeLayout  Grid.Row="0" Grid.Column="0" Margin="15" >
                         <Image Source="video" Aspect="AspectFill" x:Name="imgThumbnail" BackgroundColor="Yellow" HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand" 
                         RelativeLayout.XConstraint="{ConstraintExpression Type=RelativeToParent,Property=Width,Factor=0}"
                         RelativeLayout.YConstraint="{ConstraintExpression Type=RelativeToParent,Property=Height,Factor=0}"
                         RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent,Property=Width,Factor=1}"
                         RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent,Property=Height,Factor=1}"
                                />
                         <local:CustomImage Source="uncheck"  Aspect="AspectFill" 
                         RelativeLayout.XConstraint="{ConstraintExpression Type=RelativeToView,ElementName=imgThumbnail,Property=Width,Factor=.8}"
                         RelativeLayout.YConstraint="{ConstraintExpression Type=RelativeToView,ElementName=imgThumbnail,Property=Height,Factor=0}"
                                HeightRequest="80" 
                                >
                     <Image.GestureRecognizers>
                          <TapGestureRecognizer
                                     Tapped="OnTapGestureRecognizerTapped"
                                     NumberOfTapsRequired="1" />
                     </Image.GestureRecognizers>
                     </local:CustomImage>
                 </RelativeLayout> */



                CustomImage imgSelect = new CustomImage();
                rtlThumbnailContent.Children.Add(imgSelect, Constraint.RelativeToView(ThumbNail, (parent, view) =>
               {
                   return view.Width * .7;
               }), Constraint.RelativeToView(ThumbNail, (parent, view) =>
            {
                    return view.Width * 0;
                }));
                var sdf = new StackLayout();
                sdf.Children.Add(rtlThumbnailContent);

                grdMain.Children.Add(sdf, 0, i);


                // grdMain.Children.Add(new StackLayout(){BackgroundColor=Color.Red}, 0, 0);

                //gestureRecognizer.
                //imgSelect.

                //----------------------------------------------------------
                RelativeLayout rtlThumbnailContent1 = new RelativeLayout() { Margin = 15 };
                Image ThumbNail1 = new Image()
                {
                    Source = "video",

                    VerticalOptions = HorizontalOptions = LayoutOptions.FillAndExpand
                };

                rtlThumbnailContent1.Children.Add(ThumbNail1, Constraint.RelativeToParent((parent) =>
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




                CustomImage imgSelect1 = new CustomImage();
                rtlThumbnailContent1.Children.Add(imgSelect1, Constraint.RelativeToView(ThumbNail1, (parent, view) =>
                {
                    return view.Width * .8;
                }), Constraint.RelativeToView(ThumbNail1, (parent, view) =>
                {
                    return view.Width * 0;
                }));

                // grdMain.Children.Add(rtlThumbnailContent1, 1, 0);
                var sdfs = new StackLayout();
                sdfs.Children.Add(rtlThumbnailContent1);
                grdMain.Children.Add(sdfs, 1, i);

            }


            scrollView.Content = grdMain;
            this.Content = scrollView;
        }
    }
}
