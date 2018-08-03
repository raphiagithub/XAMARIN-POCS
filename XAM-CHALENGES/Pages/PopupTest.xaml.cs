using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XAMCHALENGES.Pages
{
    public partial class PopupTest : ContentPage
    {
        ContentView contentView = null;
        public PopupTest()
        {
            InitializeComponent();

            contentView = new ContentView();
            Label label = new Label()
            {
                Text = "Hi gabriel"
            };
            contentView.Content = label;
            AbsoluteLayout.SetLayoutFlags(contentView, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(contentView, new Rectangle()
            {
                X = 0,
                Y = 0,
                Height = 100,
                Width = 100
            });
            contentView.IsVisible = false;
            mainlayout.Children.Add(new AttachmentPopup());
        }

        bool flag = false;

        public bool ShowPopup
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
                contentView.IsVisible = flag;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            ShowPopup = true;
        }


        void Handle_Clicked1(object sender, System.EventArgs e)
        {
            ShowPopup = false; 
        }
    }

    public class AttachmentPopup : ContentView
    {
        /*
  <ContentView  BackgroundColor="#C0808080" AbsoluteLayout.LayoutBounds="0, 0, 1, 1" AbsoluteLayout.LayoutFlags="All">
            
                 <StackLayout VerticalOptions="Center" 
                              HorizontalOptions="Center"
                              BackgroundColor="White" Spacing="20">
                    
                 <Label Text="Hi gabriel" />
                 <Label Text="Hi gabriel" />
                 <Label Text="Hi gabriel" />
                    </StackLayout>
          
            </ContentView>
        */
        public AttachmentPopup()
        {
            this.BackgroundColor = Color.FromHex("#C0808080");
            AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(this, new Rectangle()
            {
                X = 0,
                Y = 0,
                Height = .99,
                Width = .99
            });

            StackLayout stkcontent = new StackLayout()
            {
                HorizontalOptions = VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                Spacing = 20,
                Padding=20
            };
            Label lbl = new Label();
            lbl.Text = "Hi gabriel";
            stkcontent.Children.Add(lbl);

            this.Content = stkcontent;
        }
    }
}
