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
    public class Input
    {
        private static readonly Input _default = new Input();

        public static Input Default
        {
            get { return _default; }
        }

        private IObservable<Key> _keyDowns;
        private IObservable<Key> _keyUps;

        public void SetSources(IObservable<Key> keyDowns, IObservable<Key> keyUps)
        {
            this._keyDowns = keyDowns;
            this._keyUps = keyUps;
            SourcesChanged.Raise(this);
        }

        public IObservable<Key> KeyDowns
        {
            get { return _keyDowns; }
        }


        public IObservable<Key> KeyUps
        {
            get { return _keyUps; }
        }

        public event EventHandler SourcesChanged;
    }
}
