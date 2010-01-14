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
using System.Collections.Generic;

namespace System.Linq
{
    public static class Int32IterationExtensions
    {
        public static IEnumerable<int> Times(this int times)
        {
            for (int i = 0; i < times; i++)
            {
                yield return i;
            }
        }
    }
}
