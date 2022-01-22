using System;
using System.Collections.Generic;
using System.Text;

namespace Kiosk.Droid
{
    public class MajorData
    {
        public string MajorName { get; set; }
        public LinkedList<DegreeData> relatedCategories;

        public MajorData()
        {
            relatedCategories = new LinkedList<DegreeData>();
        }
    }
}
