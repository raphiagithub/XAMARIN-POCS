using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XAMCHALENGES.Control;
using XAMCHALENGES.Views;

namespace XAMCHALENGES.Pages
{
    public partial class AudioPlayerPage : ContentPage
    {
        IAudioPlayer AudioService = null;
        enum PlayerState { Playing, Paused, Stopped };
        PlayerState CurrentState = PlayerState.Stopped;
        Button btnPlay;

        public AudioPlayerPage()
        {
            InitializeComponent();
            AudioService = DependencyService.Get<IAudioPlayer>();

           // Contents();
        }

        private void OnStartClicked(object sender, EventArgs eventArgs)
        {
            switch (CurrentState)
            {
                case PlayerState.Stopped:
                    {
                        AudioService.PlayAudio("");
                        btnPlay.Text = "Pause";
                        CurrentState = PlayerState.Playing;
                    }
                    break;

                case PlayerState.Playing:
                    {
                        AudioService.PauseOrResumeAudio();
                        btnPlay.Text = "Resume";
                        CurrentState = PlayerState.Paused;
                    }
                    break;

                case PlayerState.Paused:
                    {
                        AudioService.PauseOrResumeAudio();
                        btnPlay.Text = "Pause";
                        CurrentState = PlayerState.Playing;
                    }
                    break;
            }
        }

        void btnStopClicked(object sender, EventArgs eventArgs)
        {
            AudioService.StopAudio();
            btnPlay.Text = "Play";
            CurrentState = PlayerState.Stopped;
        }

       

        void Contents()
        {
           
            AbsoluteLayout absContent = new AbsoluteLayout()
            {
                BackgroundColor = Color.Gray,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            StackLayout stkUpper = new StackLayout() { BackgroundColor = Color.White };
            AbsoluteLayout.SetLayoutFlags(stkUpper, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stkUpper, new Rectangle() { X = 0, Y = 0, Width = 1, Height = .1 });

            Label lblFileName = new Label()
            {
                Text = "This is file name",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            stkUpper.Children.Add(lblFileName);
            absContent.Children.Add(stkUpper);

           

            StackLayout stkImage = new StackLayout();
            AbsoluteLayout.SetLayoutFlags(stkImage, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stkImage,new Rectangle(){X=0,Y=.5,Width=1,Height=.8});
            stkImage.Children.Add(new Label() { Text = "Here image" });
            absContent.Children.Add(stkImage);


            StackLayout stkControls = new StackLayout()
            {
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.End,
                Padding = 50
            };
            AbsoluteLayout.SetLayoutFlags(stkControls, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stkControls, new Rectangle() { X = 0, Y = 1, Width = 1, Height = .3 });

              btnPlay = new Button()
            {
                Text = "Play",
                BackgroundColor = Color.Green,
                BorderRadius = 10,
                TextColor = Color.White
            };
            btnPlay.Clicked += OnStartClicked;
          
     
            Button btnStop = new Button()
            {
                Text = "Stop",
                BackgroundColor = Color.Red,
                BorderRadius = 10,
                TextColor = Color.White
            };
            btnStop.Clicked += btnStopClicked;

            Button btnClose = new Button()
            {
                Text = "Close",
                BackgroundColor = Color.Gray,
                BorderRadius = 10
            };

            stkControls.Children.Add(btnPlay);
           // stkControls.Children.Add(new TextboxView());
            stkControls.Children.Add(btnStop);
            stkControls.Children.Add(btnClose);
            absContent.Children.Add(stkControls);

            this.Content = absContent;
        }



    }

    
}
