using System;
using System.Collections.Generic;
using System.Text;

namespace Kiosk.Models
{
    public class Category
    {
        public string CategoryTitle { get; set; }
        public List<string> RelatedDegrees { get; set; }
    }
}
