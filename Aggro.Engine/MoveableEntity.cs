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
using System.Windows.Data;
using System.Diagnostics;

namespace Aggro.Engine
{
    public class MoveableEntity : Entity
    {
        private readonly Movement _movement;
        private readonly TranslateTransform _translateTransform;
        private readonly Storyboard _storyboard;

        private double _speed = 1;

        public MoveableEntity()
        {
            _movement = new Movement();
            _movement.CurrentDirectionChanged += movement_DirectionChanged;
            _translateTransform = new TranslateTransform();

            _storyboard = new Storyboard();

            _storyboard.Children.Add(CreateAnimation("X", TranslateTransform.XProperty));
            _storyboard.Children.Add(CreateAnimation("Y", TranslateTransform.YProperty));
        }

        public Movement Movement
        {
            get { return _movement; }
        }

        public Transform Transform
        {
            get { return _translateTransform; }
        }

        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        void  movement_DirectionChanged(object sender, EventArgs e)
        {
            if (_movement.CurrentDirection == Direction.None)
            {
                this.Location = _translateTransform.Transform(this.Location);
                _storyboard.Stop();
            }
            else
            {
                _storyboard.Begin();
            }
        }

        private DoubleAnimation CreateAnimation(string movementPropertyPath, DependencyProperty transformProperty)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration((_speed * 10000D).Seconds())
            };

            Storyboard.SetTarget(animation, _translateTransform);
            Storyboard.SetTargetProperty(animation, new PropertyPath(transformProperty));

            var binding = new Binding(movementPropertyPath)
            {
                Source = _movement
            };

            BindingOperations.SetBinding(animation, DoubleAnimation.ByProperty, binding);

            return animation;
        }
    }
}
