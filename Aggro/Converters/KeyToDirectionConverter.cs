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
using Aggro.Engine;
using System.Linq;

namespace Aggro.Converters
{
    static class KeyToDirectionConverter
    {
        private static readonly Dictionary<Key, Direction> _directions = new Dictionary<Key, Direction>
        {
            { Key.W, Direction.North },
            { Key.A, Direction.West },
            { Key.S, Direction.South },
            { Key.D, Direction.East }
        };

        public static Tuple<IObservable<Direction>, IObservable<Direction>> ToDirections(UIElement element)
        {
            return Tuple.Create(
                ToDirections(element, "KeyDown"),
                ToDirections(element, "KeyUp")
                );
        }

        private static IObservable<Direction> ToDirections(UIElement element, string eventName)
        {
            return from args in Observable.FromEvent<KeyEventArgs>(element, eventName)
                   where IsDirectionKey(args.EventArgs.Key)
                   select ToDirection(args.EventArgs.Key);
        }

        private static bool IsDirectionKey(Key key)
        {
            return _directions.ContainsKey(key);
        }

        private static Direction ToDirection(Key key)
        {
            return _directions[key];
        }
    }
}
