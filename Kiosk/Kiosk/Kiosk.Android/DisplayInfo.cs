using Xamarin.Forms;

[assembly: Dependency(typeof(Kiosk.Droid.DisplayInfo))]
namespace Kiosk.Droid
{
    public class DisplayInfo : IDisplayInfo
    {
        public int GetDisplayWidth()
        {
            return (int)Android.App.Application.Context.Resources.DisplayMetrics.WidthPixels;
        }

        public int GetDisplayHeight()
        {
            return (int)Android.App.Application.Context.Resources.DisplayMetrics.HeightPixels;
        }

        public int GetDisplayDpi()
        {
            return (int)Android.App.Application.Context.Resources.DisplayMetrics.DensityDpi;
        }
    }
}