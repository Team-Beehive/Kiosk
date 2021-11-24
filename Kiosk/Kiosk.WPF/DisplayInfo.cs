using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Kiosk.WPF.DisplayInfo))]
namespace Kiosk.WPF
{
    class DisplayInfo : IDisplayInfo
    {
        public int GetDisplayDpi()
        {
            throw new NotImplementedException();
        }

        public int GetDisplayHeight()
        {
            throw new NotImplementedException();
        }

        public int GetDisplayWidth()
        {
            throw new NotImplementedException();
        }
    }
}
