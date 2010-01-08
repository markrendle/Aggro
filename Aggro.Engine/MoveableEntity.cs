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

namespace Aggro.Engine
{
    public class MoveableEntity : DependencyObject
    {
        private readonly Movement _movement;
        private readonly TranslateTransform _translateTransform;
        private readonly Storyboard _storyBoard;

        public MoveableEntity()
        {
            _movement = new Movement();
            _movement.CurrentDirectionChanged += new EventHandler(movement_DirectionChanged);
            _translateTransform = new TranslateTransform();

            _storyBoard = new Storyboard
            {
                RepeatBehavior = RepeatBehavior.Forever
            };

            _storyBoard.Children.Add(CreateAnimation(Movement.XProperty, TranslateTransform.XProperty));
            _storyBoard.Children.Add(CreateAnimation(Movement.YProperty, TranslateTransform.YProperty));
            _storyBoard.Begin();
            _storyBoard.Pause();
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
                _storyBoard.Pause();
            }
            else 
            {
                _storyBoard.Resume();
            }
        }

        private DoubleAnimation CreateAnimation(DependencyProperty movementProperty, DependencyProperty transformProperty)
        {
            var animation = new DoubleAnimation();
            animation.SetValue(DoubleAnimation.ByProperty, new Binding
            {
                Source = _movement,
                Path = new PropertyPath(movementProperty),
                Mode = BindingMode.OneWay
            });

            Storyboard.SetTarget(animation, _translateTransform);
            Storyboard.SetTargetProperty(animation, new PropertyPath(transformProperty));

            return animation;
        }
    }
}
