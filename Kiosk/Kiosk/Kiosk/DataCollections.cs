using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Kiosk
{
    public class RFLabelCollection : ObservableCollection<RFLabel>
    { }
    public class ImageCollection : ObservableCollection<Image>
    { }

    public class LabeledImage
    {
        public ImageSource Source { get; set; }
        public string LabelText { get; set; }
    }

    public class LabeledImageCollection : ObservableCollection<LabeledImage>
    { }

    public class LabeledCroppedImage : CroppedImage
    {
        public string LabelText { get; set; }
    }

    public class LabeledCroppedImageCollection : ObservableCollection<LabeledCroppedImage>
    { }

    public class CroppedImageCollection : ObservableCollection<CroppedImage>
    { }
}
