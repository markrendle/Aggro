using System.Windows.Threading;
using System.Windows;
namespace System
{
    public static class IDisposableExtensions
    {
        public static bool TryDispose(this IDisposable disposable)
        {
            if (disposable != null)
            {
                disposable.Dispose();
                return true;
            }

            return false;
        }
    }
}
