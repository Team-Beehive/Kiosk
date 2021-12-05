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

        public LinkedList<MajorData> SetMajorData()
        {
            LinkedList<MajorData> datas = new LinkedList<MajorData>();
            foreach (DocumentSnapshot document in m_dataBaseRefs)
            {
                
                MajorData tempMajor = new MajorData();
                tempMajor.MajorName = document.Id;
                tempMajor.about = document.GetValue<List<string>>("about");
                tempMajor.campuses = document.GetValue<List<string>>("campuses");
                tempMajor.type = document.GetValue<List<string>>("type");
                //tempMajor.classes = document.GetValue<List<string>>("classes");
                //tempMajor.professors = document.GetValue<List<string>>("professors");
                datas.AddLast(tempMajor);
            }
            return datas;
        }
    }
}
