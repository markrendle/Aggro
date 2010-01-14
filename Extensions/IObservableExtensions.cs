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
using System.Windows.Threading;

namespace System.Linq
{
    public static class IObservableExtensions
    {
        private static readonly Dispatcher _dispatcher = new UserControl().Dispatcher;

        public static IDisposable SubscribeOnDispatcher<T>(this IObservable<T> source, Action<T> onNext)
        {
            return source.Subscribe(item => _dispatcher.BeginInvoke(onNext, item));
        }

        public static IDisposable SubscribeOnDispatcher<T>(this IObservable<T> source, Action onNext)
        {
            return source.Subscribe(() => _dispatcher.BeginInvoke(onNext));
        }
    }
}
