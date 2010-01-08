using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Aggro.Engine
{
    public class Vector : DependencyObject
    {
        public static readonly Point NorthEast = new Point(Math.Sin(Trig.Radians(45)), Math.Cos(Trig.Radians(45)));

        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(Vector), new PropertyMetadata(0));
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(Vector), new PropertyMetadata(0));

        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        public void Transform(Transform transformation)
        {
            var newPoint = transformation.Transform(new Point(X, Y));
            X = newPoint.X;
            Y = newPoint.Y;
        }

        public void StartMoving(Vector direction)
        {
            TranslateTransform tt = new TranslateTransform();
        }
    }
}
