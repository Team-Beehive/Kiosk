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
using System.IO;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace Kiosk.Droid
{

    public class Database
    {
        private static LinkedList<MajorData> m_MajorData = new LinkedList<MajorData>();
        string fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "data.txt");
        public Database()
        {
            GetData();
            PrintData();
            //ReadAllData();
        }
        
        private static async Task<LinkedList<MajorData>> GetDataTask()
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

            return majorData;
        }

        public async void GetData()
        {
            m_MajorData = (await Task<LinkedList<MajorData>>.Run(() => GetDataTask()));
        }


        public void PrintData()
        {
            string theData = "";
            foreach (MajorData majorData in m_MajorData)
            {
                theData += "Major_Name_:::  ";
                theData += majorData.MajorName + "\n";

                foreach (DegreeData degreeData in majorData.relatedCategories)
                {
                    theData += "Degree_Name_:::  ";
                    theData += degreeData.degreeName + "\n";

                    theData += "Degree_type_:::  ";
                    foreach (string ofWors in degreeData.type)
                    {
                        theData += ofWors + " ";
                    }
                    theData += "\n";
                    theData += "Degree_about_:::  ";
                    foreach (string ofWors in degreeData.about)
                    {
                        theData += ofWors + " ";
                    }
                    theData += "\n";

                    theData += "Degree_campuses_:::  ";
                    foreach (string ofWors in degreeData.campuses)
                    {
                        theData += ofWors + " ";
                    }
                    theData += "\n\n";
                }

                theData += "\n\n\n";
                File.WriteAllText("data.txt", theData);
                theData = "";
            }
        }

        public void ReadAllData()
        {
            if (File.Exists(fileName))
            {
                string datastring =  File.ReadAllText(fileName);
            }
            else
                Console.WriteLine("Lug of nuts the file be broke");
        }
       
    }
}