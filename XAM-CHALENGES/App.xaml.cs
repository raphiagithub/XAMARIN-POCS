using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMCHALENGES.Pages;
using XAMCHALENGES.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
 

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XAM_CHALENGES
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Analytics.TrackEvent("My custom event1");
            Analytics.TrackEvent("My custom event2");
            MainPage = new AudioPlayerPage();
        }

        protected override void OnStart()
        {

            // Handle when your app starts
            Microsoft.AppCenter.AppCenter.Start("ios=0fba8b6a-2334-4156-8139-4205cbae0051;",
                                                typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
