using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Kiosk.Services;

namespace Kiosk
{

    public class RelativeImage : Image
    {
        private float heightPercent;

        public float HeightPercent
        {
            get => heightPercent;
            set
            {
                SetHeight(value);
                heightPercent = value;
            }
        }


        private float widthPercent;
        public float WidthPercent
        {
            get => widthPercent;
            set
            {
                SetWidth(value);
                widthPercent = value;
            }
        }

        private void SetWidth(float width)
        {
            int dispWidth = DependencyService.Get<IDisplayInfo>().GetDisplayWidth();
            WidthRequest = width / 200 * dispWidth; // Not sure why it needs to be 200. Bit strange
        }

        private void SetHeight(float height)
        {
            int dispHeight = DependencyService.Get<IDisplayInfo>().GetDisplayHeight();
            HeightRequest = height / 100 * dispHeight;
        }
    }
}
