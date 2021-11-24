using System;
using System.Collections.Generic;
using System.Text;

namespace Kiosk
{
    public interface IDisplayInfo
    {
        int GetDisplayWidth();
        int GetDisplayHeight();
        int GetDisplayDpi();
    }
}
