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

namespace Aggro.Engine
{
    public class Movement : DependencyObject
    {
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(Movement), new PropertyMetadata(0D));
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(Movement), new PropertyMetadata(0D));

        private static readonly Dictionary<Direction, Point> _vectors = CreateVectorDictionary();

        private Direction _currentDirection;

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

        public Direction CurrentDirection
        {
            get { return _currentDirection; }
            private set
            {
                _currentDirection = value;
                OnCurrentDirectionChanged();
            }
        }

        private Point CurrentDirectionVector
        {
            get { return _vectors[_currentDirection]; }
        }

        public void AddDirection(Direction direction)
        {
            if (!_currentDirection.HasFlag(direction))
            {
                if(_vectors.ContainsKey(_currentDirection | direction))
                {
                    CurrentDirection |= direction;
                }
            }
        }

        public void RemoveDirection(Direction direction)
        {
            if (_currentDirection.HasFlag(direction))
            {
                CurrentDirection -= direction;
            }
        }

        private void OnCurrentDirectionChanged()
        {
            X = CurrentDirectionVector.X;
            Y = CurrentDirectionVector.Y;

            CurrentDirectionChanged.Raise(this);
        }

        private static Dictionary<Direction, Point> CreateVectorDictionary()
        {
            double straight = 1000000D;
            double angular = Math.Sin(Trig.Radians(45)) * 1000000D;

            var dict = new Dictionary<Direction, Point>
            {
                { Direction.None, new Point() },
                { Direction.North, new Point(0, -straight) },
                { Direction.South, new Point(0, straight) },
                { Direction.East, new Point(straight, 0) },
                { Direction.West, new Point(-straight, 0) },
                { Direction.NorthEast, new Point(angular, -angular) },
                { Direction.NorthWest, new Point(-angular, -angular) },
                { Direction.SouthEast, new Point(angular, angular) },
                { Direction.SouthWest, new Point(-angular, angular) }
            };

            return dict;
        }

        public event EventHandler CurrentDirectionChanged;
    }
}
