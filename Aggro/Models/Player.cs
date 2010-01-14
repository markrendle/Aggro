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

namespace Aggro.Models
{
    public class Player : MoveableEntity
    {

        private IDisposable _keyDownSource;
        private IDisposable _keyUpSource;

        public Player()
        {
            Input.Default.SourceChanges.Where(src => src == InputType.Direction).Subscribe(Keyboard_SourcesChanged);
            AttachMovementHandlers();
        }

        void Keyboard_SourcesChanged()
        {
            _keyDownSource.TryDispose();
            _keyUpSource.TryDispose();

            AttachMovementHandlers();
        }

        private void AttachMovementHandlers()
        {
            if (Input.Default == null || Input.Default.KeyDowns == null || Input.Default.KeyUps == null)
            {
                _keyDownSource = _keyUpSource = null;
                return;
            }

            _keyDownSource = Input.Default.KeyDowns.Subscribe(Movement.AddDirection);
            _keyUpSource = Input.Default.KeyUps.Subscribe(Movement.RemoveDirection);
        }
    }
}
