using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;
using System.ComponentModel;

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
     * https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/resources-in-android/resources-for-varying-screens#concepts
     */
    public class RFLabel : Label, INotifyPropertyChanged
    {
        public double DP
        {
            get => (double)GetValue(DPProperty);
            set
            {
                SetFontSize(value);
                SetValue(DPProperty, value);
            }
        }

        private static readonly BindableProperty DPProperty = BindableProperty.CreateAttached("DP", typeof(double), typeof(RFLabel), 1.0);

        private void SetFontSize(double dp)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    int dpi = DependencyService.Get<IDisplayInfo>().GetDisplayDpi();
                    FontSize = dp * (dpi / 160);
                    break;
                default:
                    FontSize = dp * 2;
                    break;
            }
            
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        private new void OnPropertyChanged(string info)
        {
            base.OnPropertyChanged(info);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        
    }
}
