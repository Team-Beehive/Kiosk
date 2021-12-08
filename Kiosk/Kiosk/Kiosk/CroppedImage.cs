using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Kiosk
{
    public class CroppedImage : RelativeLayout
    {
        public CroppedImage()
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
            }
        }

        private Image internalImage;
        public ImageSource Source
        {
            get => internalImage.Source;
            set => internalImage.Source = value;
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
            }
        }

        public double ImageConstraintY
        {
            get => imageY;
            set
            {
                imageY = value;
                ConstraintChanged();
            }
        }

        public double ImageScaleX
        {
            get => scaleX;
            set
            {
                scaleX = value;
                ConstraintChanged();
            }
        }

        public double ImageScaleY
        {
            get => scaleY;
            set
            {
                scaleY = value;
                ConstraintChanged();
            }
        }

        private void ConstraintChanged()
        {
            // I can't seem to find a way to change this other than removing the whole image
            Children.Remove(internalImage);
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
    }
}
