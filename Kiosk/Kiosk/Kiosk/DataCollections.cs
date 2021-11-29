using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Kiosk
{
    public class Images : ObservableCollection<Image>
    { }

    public class LabeledImage
    {
        public ImageSource Source { get; set; }
        public string LabelText { get; set; }
    }

    public class LabeledImages : ObservableCollection<LabeledImage>
    { }
}
