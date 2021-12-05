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
        public const string project = "oit-kiosk";

        //private MajorDatabase majorDatabase = new MajorDatabase();
        private LinkedList <DocumentSnapshot> m_dataBaseRefs = new LinkedList<DocumentSnapshot>();

        public Majors(LinkedList<DocumentSnapshot> data)
        {
            m_dataBaseRefs = data;
        }

        public LinkedList<MajorData> GetMajors()
        {
            LinkedList<MajorData> datas = new LinkedList<MajorData>();
            foreach (DocumentSnapshot document in m_dataBaseRefs)
            {
                Dictionary<string, object> documentDictionary = new Dictionary<string, object>();
                MajorData tempMajor = new MajorData();
                tempMajor.MajorName = document.Id;
                tempMajor.about = documentDictionary["about"] as List<string>;
                tempMajor.campuses = documentDictionary["campuses"] as List<string>;
                tempMajor.type = documentDictionary["type"] as List<string>;
                datas.AddLast(tempMajor);
            }
            return datas;
        }
    }
}
