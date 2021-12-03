using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Kiosk
{
    public class ImageCollection : ObservableCollection<Image>
    { }

    public class LabeledImage
    {
        public ImageSource Source { get; set; }
        public string LabelText { get; set; }
    }

    public class LabeledImageCollection : ObservableCollection<LabeledImage>
    { }

    public class TextBody : INotifyPropertyChanged
    {
        private string _text;
        public string Text { get => _text; set { _text = value; Notify("Text"); } }

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
