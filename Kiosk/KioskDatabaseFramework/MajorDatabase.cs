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
        private static FirestoreDb db;
        Majors majors;

        private static string fileIOpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"MajorData.txt";
        public const string project = "oit-kiosk";

        public MajorDatabase()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\zaneo\\Desktop\\School Fall21\\TermProject\\Database\\oit-kiosk-firebase-adminsdk-u24sq-8f7958c50f.json");
            majors = new Majors(GetMajorData());
            PrintToFile();
        }

        private static void InitializeProject()
        {
            db = FirestoreDb.Create(project);
        }

        private static async Task <LinkedList<DocumentSnapshot>> db_StoreMajorDataMemory()
        {
            InitializeProject();
            CollectionReference userRef = db.Collection("pages").Document("Majors").Collection("Degrees");
            QuerySnapshot snapshot = await userRef.GetSnapshotAsync();

            LinkedList<DocumentSnapshot> tempDocs = new LinkedList<DocumentSnapshot>();
            foreach (DocumentSnapshot document in snapshot.Documents)
                tempDocs.AddLast(document);

            return tempDocs;
        }

        public LinkedList<DocumentSnapshot> GetMajorData()
        {
            Task<LinkedList<DocumentSnapshot>> task = db_StoreMajorDataMemory();
            Task<LinkedList<DocumentSnapshot>>.Run(() => task);
            LinkedList<DocumentSnapshot> documentSnapshots = task.Result;
            return documentSnapshots;
        }

        public void PrintToFile()
        {
            LinkedList<MajorData> majorsData = majors.GetMajors();

            try
            {
                StreamWriter sw = new StreamWriter(fileIOpath, true, Encoding.ASCII);

                foreach (MajorData major in majorsData)
                    sw.Write(major);

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
