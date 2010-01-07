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

namespace SilverlightApplication1.Models
{
    public class Player : DependencyObject
    {
        // Using a DependencyProperty as the backing store for XVelocity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XVelocityProperty =
            DependencyProperty.Register("XVelocity", typeof(double), typeof(Player), new PropertyMetadata(0));
        // Using a DependencyProperty as the backing store for YVelocity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YVelocityProperty =
            DependencyProperty.Register("YVelocity", typeof(double), typeof(Player), new PropertyMetadata(0));

        public double XVelocity
        {
            get { return (double)GetValue(XVelocityProperty); }
            set { SetValue(XVelocityProperty, value); }
        }

        public double YVelocity
        {
            get { return (double)GetValue(YVelocityProperty); }
            set { SetValue(YVelocityProperty, value); }
        }
    }
}
