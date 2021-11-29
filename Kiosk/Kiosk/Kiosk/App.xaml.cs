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

<<<<<<< HEAD
            //MainPage = new MajorsListPage();
            MainPage = new NavigationPage(new MajorsListPage());
=======
            MainPage = new Navigation();
>>>>>>> a41d75e4c2995e7317506bb553e4edf2a36a2c37
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
