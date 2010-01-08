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
    [Flags]
    public enum Direction
    {
        None = 0,
        North = 0x01,
        East = 0x02,
        South = 0x04,
        West = 0x08,
        NorthEast = North | East,
        NorthWest = North | West,
        SouthEast = South | East,
        SouthWest = South | West
    }
}
