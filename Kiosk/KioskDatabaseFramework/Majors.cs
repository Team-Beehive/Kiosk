using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskDatabaseFramework
{
    /// <summary>
    /// class for acessing and managing major data
    /// </summary>
    public class Majors
    {
        private static FirestoreDb db;
        private static LinkedList<MajorData> m_MajorData = new LinkedList<MajorData>();

        public Majors()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\zaneo\\Desktop\\Desktop Stuff\\School\\School Fall21\\TermProject\\Database\\oit-kiosk-firebase-adminsdk-u24sq-8f7958c50f.json");
        }

        private static void InitializeProject()
        {
            db = FirestoreDb.Create("oit-kiosk");
        }

        private static async Task<LinkedList<MajorData>> GetMajorsDataInternal()
        {
            InitializeProject();
            LinkedList<MajorData> majorData = new LinkedList<MajorData>();

            CollectionReference collection = db.Collection("pages");
            QuerySnapshot snapshot = await collection.GetSnapshotAsync();

            CollectionReference collection2 = db.Collection("pages").Document("Majors").Collection("Degrees");
            QuerySnapshot snapshot2 = await collection2.GetSnapshotAsync();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                    MajorData tempMajor = new MajorData();
                    tempMajor.MajorName = document.Id;

                    foreach (DocumentSnapshot documentb in snapshot2.Documents)
                    {
                        DegreeData degreeData = new DegreeData();
                        degreeData.degreeName = documentb.Id;
                        degreeData.about = documentb.GetValue<List<string>>("about");
                        degreeData.campuses = documentb.GetValue<List<string>>("campuses");
                        degreeData.type = documentb.GetValue<List<string>>("type");
                        tempMajor.relatedCategories.AddLast(degreeData);
                    }

                    majorData.AddLast(tempMajor);
            }

            m_MajorData = majorData;
            return majorData;
        }

        public LinkedList<MajorData> GetMajorsData()
        {
            GetMajorsDataInternal().Wait();
            return m_MajorData;
        }
    }
}
