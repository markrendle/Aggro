using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Aggro.Engine;
using Aggro.Utils;

namespace Aggro.Models
{
    public class Player : MoveableEntity
    {
        private IDisposable _directionStartSource;
        private IDisposable _directionStopSource;
        private IDisposable _rotationSource;
        private IDisposable _rotationTimer;
        private Weapon _weapon = new Weapon();

        public Player()
        {
            Size = new Size(32, 32);
            Input.Default.SourceChanges.Where(src => src == InputType.Direction).Subscribe(Keyboard_SourcesChanged);
            AttachMovementHandlers();
            AttachRotationHandler();
        }

        public Weapon Weapon
        {
            get { return _weapon; }
        }

        void Keyboard_SourcesChanged()
        {
            _directionStartSource.TryDispose();
            _directionStopSource.TryDispose();
            _directionStartSource = _directionStopSource = null;

            AttachMovementHandlers();
        }

        private void AttachMovementHandlers()
        {
            if (Check.AnyNull(Input.Default, Input.Default.DirectionStarts, Input.Default.DirectionStops)) return;

            _directionStartSource = Input.Default.DirectionStarts.SubscribeOnDispatcher(Movement.AddDirection);
            _directionStopSource = Input.Default.DirectionStops.SubscribeOnDispatcher(Movement.RemoveDirection);
        }

        void MouseSourcesChanged()
        {
            _rotationSource.TryDispose();
            _rotationTimer.TryDispose();

            AttachRotationHandler();
        }

        private void AttachRotationHandler()
        {
            if (Check.AnyNull(Input.Default, Input.Default.MouseMoves)) return;

            _rotationTimer = Observable.Generate<object, object>(null,
                o => true,
                o => o,
                o => 100,
                o => o)
                .SubscribeOnDispatcher(() => Weapon.SetRotation(Trig.GetAngleFromYAxis(CurrentCenter, Input.Default.MousePosition)));

            _rotationSource = Input.Default.MouseMoves.SubscribeOnDispatcher(point => Weapon.SetRotation(Trig.GetAngleFromYAxis(CurrentCenter, point)));
        }
    }
}
