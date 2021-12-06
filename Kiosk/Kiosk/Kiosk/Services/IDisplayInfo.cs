using System;
using System.Collections.Generic;
using System.Text;

namespace Kiosk.Services
{
    public interface IDisplayInfo
    {
        int GetDisplayWidth();
        int GetDisplayHeight();
        int GetDisplayDpi();
    }
}
