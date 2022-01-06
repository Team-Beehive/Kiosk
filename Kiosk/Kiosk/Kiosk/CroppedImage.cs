using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Kiosk
{
    public class CroppedImage : RelativeLayout, INotifyPropertyChanged
    {
        public CroppedImage() : base()
        {
            internalImage = new Image();

            IsClippedToBounds = true;
            CropAspect = S.Square;
            Orientation = O.Horizontal;
            VerticalOptions = LayoutOptions.End;
            HorizontalOptions = LayoutOptions.End;

            ImageConstraintX = 0;
            ImageConstraintY = 0;
            ImageScaleX = 1;
            ImageScaleY = 1;


            Children.Add(internalImage,
                // These constraints are in the correct but arbitrary order
                // XConstraint
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * ImageConstraintX;
                }),
                //YConstraint
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * ImageConstraintY;
                }),
                // XScale
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * ImageScaleX;
                }),
                // YScale
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * ImageScaleY;
                })
            );
        }

        public enum S
        {
            Square,
            FourByThree,
            SixteenByNine
        }

        private static readonly double[] doubleRatio =
        {
            1.0,
            1.33,
            1.77
        };

        public enum O
        {
            Vertical,
            Horizontal
        }

        private O orientation;
        public O Orientation
        {
            get => orientation;
            set
            {
                orientation = value;
                SetCropAspect(cropAspect, Width);
                OnPropertyChanged("Orientation");

            }
        }

        private S cropAspect;
        public S CropAspect
        {
            get => cropAspect;
            set
            {
                cropAspect = value;
                SetCropAspect(value, Width);
                OnPropertyChanged("CropAspect");

            }
        }

        private Image internalImage;
        public Xamarin.Forms.ImageSource Source
        {
            get => internalImage.Source;
            set
            { 
                internalImage.Source = value;
                OnPropertyChanged("Source");
            }
        }

        private double imageX;
        private double imageY;
        private double scaleX;
        private double scaleY;

        public double ImageConstraintX
        {
            get => imageX;
            set
            {
                imageX = value;
                ConstraintChanged();
                OnPropertyChanged("ImageConstraintX");

            }
        }

        public double ImageConstraintY
        {
            get => imageY;
            set
            {
                imageY = value;
                ConstraintChanged();
                OnPropertyChanged("ImageConstraintY");

            }
        }

        public double ImageScaleX
        {
            get => scaleX;
            set
            {
                scaleX = value;
                ConstraintChanged();
                OnPropertyChanged("ImageScaleX");
            }
        }

        public double ImageScaleY
        {
            get => scaleY;
            set
            {
                scaleY = value;
                ConstraintChanged();
                OnPropertyChanged("ImageScaleY");

            }
        }

        private void ConstraintChanged()
        {
            // I can't seem to find a way to change this other than removing the whole image
            _ = Children.Remove(internalImage);
            Children.Add(internalImage,
                // These constraints are in the correct but arbitrary order
                // XConstraint
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * ImageConstraintX;
                }),
                //YConstraint
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * ImageConstraintY;
                }),
                // XScale
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Width * ImageScaleX;
                }),
                // YScale
                Constraint.RelativeToParent((parent) =>
                {
                    return parent.Height * ImageScaleY;
                }));
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            SetCropAspect(cropAspect, width);
        }

        private void SetCropAspect(S ratio, double width)
        {

            double ratioInDouble = doubleRatio[(int)ratio];

            switch (orientation)
            {
                case O.Vertical:
                    HeightRequest = width * ratioInDouble;
                    break;
                case O.Horizontal:
                    HeightRequest = width / ratioInDouble;
                    break;
                default:
                    Debug.WriteLine("This isn't supposed to happen");
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
