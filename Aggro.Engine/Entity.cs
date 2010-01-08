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
    public class Entity : DependencyObject
    {
        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register("Location", typeof(Point), typeof(Entity), new PropertyMetadata(new Point(0, 0)));

        public Point Location
        {
            get { return (Point)GetValue(LocationProperty); }
            protected set { SetValue(LocationProperty, value); }
        }
    }
}
