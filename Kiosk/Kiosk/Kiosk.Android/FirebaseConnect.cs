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
using Xamarin.Forms;
using System.Threading.Tasks;
using Firebase.Firestore;
using Android.Gms.Tasks;

[assembly: Dependency(typeof(Kiosk.Droid.FirebaseConnect))]
namespace Kiosk.Droid
{
    class FirebaseConnect : IFirebaseConnect
    {
        public Task<MajorData> GetMajor(string Major)
        {
            var tcs = new TaskCompletionSource<MajorData>();

            FirebaseFirestore.Instance
                .Collection("pages")
                .Document("Majors")
                .Collection("Degrees")
                .Document(Major)
                .Get()
                .AddOnCompleteListener(new OnCompleteListener(tcs));

            return tcs.Task;
        }

        public Task<LinkedList<string>> GetMajorsList()
        {
            var tcs = new TaskCompletionSource<LinkedList<string>>();

            FirebaseFirestore.Instance
                .Collection("pages")
                .Document("Majors")
                .Collection("Degrees")
                .Get()
                .AddOnCompleteListener(new OnListComplete(tcs));

            return tcs.Task;
        }
    }

    internal class OnListComplete : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<LinkedList<string>> tcs;

        public OnListComplete(TaskCompletionSource<LinkedList<string>> tcs)
        {
            this.tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                Java.Lang.Object result = task.Result;
                if (result is CollectionReference col)
                {
                    QuerySnapshot snapshot = await col.GetSnapshotAsync();
                    var degrees = new LinkedList<string>();
                    foreach (DocumentReference d in col.Documents)
                    {

                    }

                }
            }

            tcs.TrySetResult(default(LinkedList<string>));
        }
    }

    internal class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<MajorData> tcs;

        public OnCompleteListener(TaskCompletionSource<MajorData> tcs)
        {
            this.tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                Java.Lang.Object result = task.Result;
                if (result is DocumentSnapshot doc)
                {
                    var major = new MajorData();
                    major.about = doc.GetArray("about");
                    major.campuses = doc.GetString("campuses");

                }
            }

            tcs.TrySetResult(default(MajorData));
        }
    }
}