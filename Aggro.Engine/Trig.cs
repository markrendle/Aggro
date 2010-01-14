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
    public static class Trig
    {
        private static readonly double _radianRatio = Math.PI / 180;
        private static readonly double _degreeRatio = 180 / Math.PI;

        public static double Radians(double degrees)
        {
            return degrees * _radianRatio;
        }

        public static double Degrees(double radians)
        {
            return radians * _degreeRatio;
        }

        public static double GetAngleFromXAxis(Point origin, Point target)
        {
            var dx = target.X - origin.X;
            if (dx == 0) return 0;

            var dy = target.Y - origin.Y;

            return Degrees(Math.Atan(dy / dx));
        }

        public static double GetAngleFromYAxis(Point origin, Point target)
        {
            var angle = GetAngleFromXAxis(origin, target) + 90;

            if (target.X < origin.X) angle += 180;

            return angle;
        }
    }
}
