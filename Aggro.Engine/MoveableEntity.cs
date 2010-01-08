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

        public MoveableEntity()
        {
            _movement = new Movement();
            _movement.CurrentDirectionChanged += movement_DirectionChanged;
            _translateTransform = new TranslateTransform();

            _storyboard = new Storyboard { RepeatBehavior = new RepeatBehavior(1) };

            _storyboard.Children.Add(CreateAnimation("X", TranslateTransform.XProperty));
            _storyboard.Children.Add(CreateAnimation("Y", TranslateTransform.YProperty));

            _storyboard.Completed += new EventHandler(_storyboard_Completed);
        }

        void _storyboard_Completed(object sender, EventArgs e)
        {
            if (_movement.CurrentDirection != Direction.None)
            {
                _storyboard.Begin();
            }
        }

        public Movement Movement
        {
            get { return _movement; }
        }

        public Transform Transform
        {
            get { return _translateTransform; }
        }

        void  movement_DirectionChanged(object sender, EventArgs e)
        {
            if (_movement.CurrentDirection == Direction.None)
            {
                Debug.WriteLine("{0},{1}", _translateTransform.X, _translateTransform.Y);
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
                RepeatBehavior = new RepeatBehavior(1)
            };

            Storyboard.SetTarget(animation, _translateTransform);
            Storyboard.SetTargetProperty(animation, new PropertyPath(transformProperty));

            var binding = new Binding(movementPropertyPath)
            {
                Source = _movement
            };

            BindingOperations.SetBinding(animation, DoubleAnimation.ByProperty, binding);

            animation.Completed += new EventHandler(animation_Completed);

            return animation;
        }

        void animation_Completed(object sender, EventArgs e)
        {
            //_storyboard.Begin();
        }
    }
}
