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
            internalImage = new Image 
            {
                
            };
            VerticalOptions = LayoutOptions.End;
            HorizontalOptions = LayoutOptions.End;
            ShapeRatio = S.Square;
            Orientation = O.Horizontal;
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
                }));
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

        

        public O Orientation
        {
            get => orientation;
            set
            {
                orientation = value;
                SetShapeRatio(shapeRatio);
            }
        }


        private O orientation;

        private S shapeRatio;
        public S ShapeRatio
        {
            get => shapeRatio;
            set
            {
                shapeRatio = value;
                SetShapeRatio(value);
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
                ConstraintChanged("ImageX");
            };
        }

        private void ConstraintChanged(string Constraint)
        {
            
            switch (Constraint)
            {
                case "ImageX":
                    this.Get(;
                    break;
            }
        }

        public double ImageConstraintY { get => imageY; set => imageY = value; }
        public double ImageScaleX { get => scaleX; set => scaleX = value; }
        public double ImageScaleY { get => scaleY; set => scaleY = value; }

        private void SetShapeRatio(S ratio)
        {
            double ratioInDouble = doubleRatio[(int)ratio];

            switch (orientation)
            {
                case O.Vertical:
                    HeightRequest = Width * ratioInDouble;
                    break;
                case O.Horizontal:
                    HeightRequest = Width / ratioInDouble;
                    break;
                default:
                    Debug.WriteLine("This isn't supposed to happen");
                    break;
            }
        }
    }
}
