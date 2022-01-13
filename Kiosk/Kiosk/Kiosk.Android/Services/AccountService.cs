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
using Xamarin.Essentials;
using Xamarin.Forms;
using Firebase.Auth;
using Firebase;
using System.Threading.Tasks;

namespace Kiosk.Droid.Services
{
    public class AccountService : IAccountService
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            /*
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
            */
            throw new NotImplementedException();
        }
    }

}