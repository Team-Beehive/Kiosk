using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Google.Cloud.Firestore;

namespace Kiosk
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //OnStart();
            //MainPage = new BuildingsPage();
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", new Uri("./oit-kiosk-firebase-adminsdk-u24sq-8f7958c50f.json", UriKind.Relative).ToString());
            MainPage = new NavigationPage(new MajorsListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //This line should create the environment variable with a relative path to the json file
            
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
