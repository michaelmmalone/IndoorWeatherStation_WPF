using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace IndoorWeatherStation_WPF.Utility
{
    internal static class Helper
    {
        public static async Task RunOnUiThread(Action callback)
        {
            await Helper.DoRunOnUiThread(callback);
        }

        public static void RunOnUiThreadAndWait(Action callback)
        {
            Helper.DoRunOnUiThread(callback).Wait();
        }

        private static async Task DoRunOnUiThread(Action callback)
        {
            if (Application.Current != null)
            {
                // This works even for unit/component tests because of the test host
                // application.
                await Application.Current.Dispatcher.InvokeAsync(
                    callback,
                    DispatcherPriority.Background);
            }
        }
    }
}
