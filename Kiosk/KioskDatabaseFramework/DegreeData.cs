using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskDatabaseFramework
{
    public class DegreeData
    {
        public string degreeName { get; set; }
        public List<string> campuses { get; set; }
        public List<string> about { get; set; }
        public List<string> type { get; set; }
    }
}
