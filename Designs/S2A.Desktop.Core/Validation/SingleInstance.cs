using System.Threading;

namespace S2A.Desktop.Core
{
    public static class SingleInstance
    {
        private static Mutex _mutex = null;

        public static bool IsAlreadyRunning(string appName)
        {
            _mutex = new Mutex(true, appName, out bool createdNew);

            return !createdNew;
        }
    }
}
