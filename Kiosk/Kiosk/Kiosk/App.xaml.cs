using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kiosk
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new BuildingsPage();
            //MainPage = new NavigationPage(new MajorsListPage());
            MainPage = new MainNav();
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
