using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Kiosk
{
    public class CroppedImage : RelativeLayout
    {
        public CroppedImage()
        {
            internalImage = new Image();
            ShapeRatio = S.Square;
            Orientation = O.Horizontal;
            ImageConstraintX = 0;
            ImageConstraintY = 0;
            ImageScaleX = 1;
            ImageScaleY = 1;
            this.Children.Add(internalImage,
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

        public enum O
        {
            Vertical,
            Horizontal
        }

        private static double[] doubleRatio =
        {
            1.0,
            1.33,
            1.77
        };

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

        public double ImageConstraintX { get => imageX; set => imageX = value; }
        public double ImageConstraintY { get => imageY; set => imageY = value; }
        public double ImageScaleX { get => scaleX; set => scaleX = value; }
        public double ImageScaleY { get => scaleY; set => scaleY = value; }

        private Image internalImage;
        public ImageSource Source {
            get => internalImage.Source;
            set => internalImage.Source = value; 
        }

        private double imageX;
        private double imageY;
        private double scaleX;
        private double scaleY;

        private void SetShapeRatio(S ratio)
        {
            double ratioInDouble = doubleRatio[(int)ratio];

            switch (orientation)
            {
                case O.Vertical:
                    WidthRequest = Height * ratioInDouble;
                    break;
                case O.Horizontal:
                    HeightRequest = Width * ratioInDouble;
                    break;
            }
        }
    }
}
