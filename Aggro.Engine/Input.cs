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
    public class Input : DependencyObject
    {
        public static readonly DependencyProperty MousePositionProperty =
            DependencyProperty.Register("MousePosition", typeof(Point), typeof(Input), new PropertyMetadata(new Point()));

        private static readonly Input _default = new Input();

        public static Input Default
        {
            get { return _default; }
        }

        private readonly Subject<InputType> _sourceChanges = new Subject<InputType>();

        private IObservable<Direction> _directionStarts;
        private IObservable<Direction> _directionStops;

        private IObservable<Point> _mouseLeftDowns;
        private IObservable<Point> _mouseLeftUps;

        private IObservable<Point> _mouseRightDowns;
        private IObservable<Point> _mouseRightUps;

        private IObservable<Point> _mouseMoves;

        public void SetDirectionSources(Tuple<IObservable<Direction>, IObservable<Direction>> sources)
        {
            SetDirectionSources(sources.Item1, sources.Item2);
        }

        public void SetDirectionSources(IObservable<Direction> starts, IObservable<Direction> stops)
        {
            this._directionStarts = starts;
            this._directionStops = stops;
            _sourceChanges.OnNext(InputType.Direction);
        }

        public void SetMouseLeftButtonSources(Tuple<IObservable<Point>, IObservable<Point>> sources)
        {
            SetMouseLeftButtonSources(sources.Item1, sources.Item2);
        }

        public void SetMouseLeftButtonSources(IObservable<Point> downs, IObservable<Point> ups)
        {
            this._mouseLeftDowns = downs;
            this._mouseLeftUps = ups;
            _sourceChanges.OnNext(InputType.MouseLeftButton);
        }

        public void SetMouseRightButtonSources(Tuple<IObservable<Point>, IObservable<Point>> sources)
        {
            SetMouseRightButtonSources(sources.Item1, sources.Item2);
        }

        public void SetMouseRightButtonSources(IObservable<Point> downs, IObservable<Point> ups)
        {
            this._mouseRightDowns = downs;
            this._mouseRightUps = ups;
            _sourceChanges.OnNext(InputType.MouseRightButton);
        }

        public void SetMouseMoveSource(IObservable<Point> moves)
        {
            this.SetBinding(MousePositionProperty, moves);
            this._mouseMoves = moves;
            _sourceChanges.OnNext(InputType.Mouse);
        }

        public IObservable<Direction> DirectionStarts
        {
            get { return _directionStarts; }
        }


        public IObservable<Direction> DirectionStops
        {
            get { return _directionStops; }
        }

        public IObservable<Point> MouseMoves
        {
            get { return _mouseMoves; }
        }

        public Point MousePosition
        {
            get { return (Point)GetValue(MousePositionProperty); }
            set { SetValue(MousePositionProperty, value); }
        }

        public IObservable<InputType> SourceChanges
        {
            get { return _sourceChanges; }
        }
    }
}
