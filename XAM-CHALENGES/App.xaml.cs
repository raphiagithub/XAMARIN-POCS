using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMCHALENGES.Pages;
using XAMCHALENGES.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XAM_CHALENGES
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CarouselViewPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
