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
        private static readonly Dictionary<Key, Direction> _directions = new Dictionary<Key, Direction>
        {
            { Key.W, Direction.North },
            { Key.A, Direction.West },
            { Key.S, Direction.South },
            { Key.D, Direction.East }
        };

        private IDisposable _keyDownSource;
        private IDisposable _keyUpSource;

        public Player()
        {
            Input.Default.SourcesChanged += Default_SourcesChanged;
            AttachMovementHandlers();
        }

        void Default_SourcesChanged(object sender, EventArgs e)
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

            _keyDownSource = GetDirectionSource(Input.Default.KeyDowns).Subscribe(Movement.AddDirection);
            _keyUpSource = GetDirectionSource(Input.Default.KeyUps).Subscribe(Movement.RemoveDirection);
        }

        private IObservable<Direction> GetDirectionSource(IObservable<Key> source)
        {
            return from key in source
                   where _directions.ContainsKey(key)
                   select _directions[key];
        }
    }
}
