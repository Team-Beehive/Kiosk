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
    /// class for using the database
    /// </summary>
    public class MajorDatabase
    {
        private static string fileIOpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"MajorData.txt";
        public const string project = "oit-kiosk";
        private static FirestoreDb db;
        Majors majors;
        private static LinkedList<DocumentSnapshot> m_documentSnapshots = new LinkedList<DocumentSnapshot>();

        public MajorDatabase()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\zaneo\\Desktop\\School Fall21\\TermProject\\Database\\oit-kiosk-firebase-adminsdk-u24sq-8f7958c50f.json");
            GetMajorData().Wait();
            majors = new Majors(m_documentSnapshots);
            PrintToFile();
        }

        private static void InitializeProject()
        {
            db = FirestoreDb.Create(project);
        }

        private static async Task<LinkedList<DocumentSnapshot>> GetMajorData()
        {
            InitializeProject();
            LinkedList<DocumentSnapshot> documentSnapshots = new LinkedList<DocumentSnapshot>();

            CollectionReference collection = db.Collection("pages").Document("Majors").Collection("Degrees");
            QuerySnapshot snapshot = await collection.GetSnapshotAsync();

            foreach (DocumentSnapshot document in snapshot.Documents)
                documentSnapshots.AddLast(document);

            m_documentSnapshots = documentSnapshots;
            return documentSnapshots;
        }

        public void PrintToFile()
        {
            LinkedList<MajorData> majorsData = majors.GetMajors();

            try
            {
                StreamWriter sw = new StreamWriter(fileIOpath, true, Encoding.ASCII);

                foreach (MajorData majorData in majorsData)
                {
                    sw.WriteLine(majorData.MajorName + majorData.type + majorData.Classes + majorData.Professors + majorData.campuses + majorData.about);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
