using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CloudFirestore;
using Google.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Kiosk.Droid
{

    public class Database
    {
    private static LinkedList<MajorData> m_MajorData = new LinkedList<MajorData>();

        public Database()
        {
            GetData();
        }

        //Go through everything in the database and set it to some varaible
        async void GetData()
        {
            var collection1 = await CrossCloudFirestore.Current
                                            .Instance
                                            .Collection("pages")
                                            .GetAsync();

            var collection2 = await CrossCloudFirestore.Current
                                           .Instance
                                           .Collection("pages")
                                           .Document("Majors")
                                           .Collection("Degrees")
                                           .GetAsync();

            LinkedList<MajorData> majorData = new LinkedList<MajorData>();

            foreach (IDocumentSnapshot document in collection1.Documents)
            {
                MajorData tempMajor = new MajorData();
                tempMajor.MajorName = document.Id;

                foreach (IDocumentSnapshot documentb in collection2.Documents)
                {
                    DegreeData degreeData = new DegreeData();
                    degreeData.degreeName = documentb.Id;
                    degreeData.about = documentb.Get<List<string>>("about");
                    degreeData.campuses = documentb.Get<List<string>>("campuses");
                    degreeData.type = documentb.Get<List<string>>("type");
                    tempMajor.relatedCategories.AddLast(degreeData);
                }

                majorData.AddLast(tempMajor);
            }

            m_MajorData = majorData;
        }

    }


}