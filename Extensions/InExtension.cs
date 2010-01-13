using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace System.Linq
{
    public static class InExtension
    {
        public static bool In<T>(this T value, params T[] list)
        {
            return list.Contains(value);
        }
    }
}
