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

namespace System.Windows
{
    public static class UIElementExtensions
    {
        public static Point GetCanvasLocation(this UIElement element)
        {
            return new Point((double)element.GetValue(Canvas.LeftProperty), (double)element.GetValue(Canvas.TopProperty));
        }

        public static void SetCanvasLocation(this UIElement element, Point location)
        {
            element.SetValue(Canvas.LeftProperty, location.X);
            element.SetValue(Canvas.TopProperty, location.Y);
        }
    }
}
