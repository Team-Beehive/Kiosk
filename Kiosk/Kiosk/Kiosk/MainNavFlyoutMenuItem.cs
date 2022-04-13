using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk
{
    public class MainNavFlyoutMenuItem
    {
        public MainNavFlyoutMenuItem()
        {
            TargetType = typeof(MainNavFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
