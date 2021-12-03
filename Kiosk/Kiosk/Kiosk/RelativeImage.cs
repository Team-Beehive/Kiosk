using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Kiosk
{

    public class RelativeImage : Image
    {
        private float _heightPercent;

        public float HeightPercent
        {
            get => _heightPercent;
            set
            {
                SetHeight(value);
                _heightPercent = value;
            }
        }


        private float _widthPercent;
        public float WidthPercent
        {
            get => _widthPercent;
            set
            {
                SetWidth(value);
                _widthPercent = value;
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
