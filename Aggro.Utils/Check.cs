using System.Linq;

namespace Aggro.Utils
{
    public static class Check
    {
        public static bool AllNull(params object[] args)
        {
            return args.All(Null);
        }

        public static bool AnyNull(params object[] args)
        {
            return args.Any(Null);
        }

        public static bool Null(object arg)
        {
            return arg == null;
        }
    }
}
