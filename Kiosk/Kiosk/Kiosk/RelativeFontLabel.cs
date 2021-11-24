using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;

namespace Kiosk
{
    /*
     * RFLabel
     *  Relative Font Label
     * Controls the consistancy of font size per device. Allows for font sizes that are
     * relative to the screen dpi, instead of to units of measurement.
     * Made because the named font sizes can be different for different devices or screen resolutions.
     * 
     * Not sure if this is nessasary, will have to test on the kiosks.
     * https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/fonts#understand-named-font-sizes
     * https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/common-properties#units-of-measurement
     * https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/label
     */
    class RFLabel : Label
    {
        private double fontSizeRelative;
        public double FontSizeRelative
        {
            get { return fontSizeRelative; }
            set
            {
                SetFontSize(value);
                fontSizeRelative = value;
            }
        }
        void SetFontSize(double fontSizeRelative)
        {
            int dpi = DependencyService.Get<IDisplayInfo>().GetDisplayDpi();
            FontSize = dpi * (fontSizeRelative / 200);
        }
    }
}
