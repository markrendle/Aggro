using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Aggro.Converters
{
    static class MouseToPointConverter
    {
        public static Tuple<IObservable<Point>, IObservable<Point>> LeftButtonToPoints(UIElement element)
        {
            return ButtonToPoints(element, Button.Left);
        }

        public static Tuple<IObservable<Point>, IObservable<Point>> RightButtonToPoints(UIElement element)
        {
            return ButtonToPoints(element, Button.Right);
        }

        public static IObservable<Point> MoveToPoints(UIElement element)
        {
            return MouseEventToPoints<MouseEventArgs>(element, "MouseMove");
        }

        private static Tuple<IObservable<Point>, IObservable<Point>> ButtonToPoints(UIElement element, Button button)
        {
            return Tuple.Create(
                MouseEventToPoints<MouseButtonEventArgs>(element, string.Format("Mouse{0}ButtonDown", button)),
                MouseEventToPoints<MouseButtonEventArgs>(element, string.Format("Mouse{0}ButtonUp", button))
                );
        }

        private static IObservable<Point> MouseEventToPoints<TArgs>(UIElement element, string eventName)
            where TArgs : MouseEventArgs
        {
            return Observable.FromEvent<TArgs>(element, eventName)
                .Select(args => args.EventArgs.GetPosition(element));
        }

        private enum Button
        {
            Left,
            Right
        }
    }
}
