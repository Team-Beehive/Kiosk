using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Cloud.Firestore;
using System.Threading.Tasks;


namespace Kiosk.Droid
{
    public class Firestore
    {
        private static FirestoreDb db;


        private static void InitializeProject()
        {
            db = FirestoreDb.Create("oit-kiosk");
        }
        public Firestore()
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\zaneo\\Desktop\\Desktop Stuff\\School\\School Fall21\\TermProject\\Database\\oit-kiosk-firebase-adminsdk-u24sq-8f7958c50f.json");
            InitializeProject();
        }


    }
}