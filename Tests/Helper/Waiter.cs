using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Helper
{
    internal static class Waiter
    {
        //public static void Until(Func<bool> condition)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (condition())
        //        {
        //            return;
        //        }

        //        Task.Delay(200).Wait();
        //    }

        //    Assert.Fail("Wait until timed out.");
        //}

        public const int TimeoutDuration = 10000;

        /// <summary>
        /// Wait on the handle iteratively pumping messages between iterations.
        /// </summary>
        public static bool Wait(EventWaitHandle wait)
        {
            bool waitCompleted = false;

            for (int i = 0; i < TimeoutIterationCount && !waitCompleted; i++)
            {
                waitCompleted = wait.WaitOne(100);
                Waiter.DoEvents();
            }

            return waitCompleted;
        }

        public static bool Until(
            Func<bool> condition,
            bool throwOnTimeout = true)
        {
            bool waitCompleted = false;

            for (int i = 0; i < TimeoutIterationCount && !waitCompleted; i++)
            {
                if (condition())
                {
                    waitCompleted = true;
                    break;
                }

                Waiter.DoEvents(50);
            }

            if (!waitCompleted && throwOnTimeout)
            {
                waitCompleted.Should().BeTrue();
            }

            return waitCompleted;
        }


        /// <summary>
        /// Pumps messages for a fixed number of MS
        /// </summary>
        /// <param name="numMilliseconds">
        /// Number of milliseconds to wait.
        /// </param>
        public static void DoEvents(int numMilliseconds)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            while (sw.ElapsedMilliseconds < numMilliseconds)
            {
                Waiter.DoEvents();
                ComponentDispatcher.RaiseIdle();
                System.Threading.Thread.Sleep(0);
            }
            sw.Stop();
        }

        /// <summary>
        /// Processes all UI messages currently in the message queue.
        /// </summary>
        public static void DoEvents()
        {
            // Create new nested message pump.
            DispatcherFrame nestedFrame = new DispatcherFrame();

            // Dispatch a callback to the current message queue, when getting called, 
            // this callback will end the nested message loop.
            // note that the priority of this callback should be lower than the that of UI event messages.
            DispatcherOperation exitOperation = Dispatcher.CurrentDispatcher.BeginInvoke(
                DispatcherPriority.Background, exitFrameCallback, nestedFrame);

            // pump the nested message loop, the nested message loop will immediately 
            // process the messages left inside the message queue.
            Dispatcher.PushFrame(nestedFrame);

            // If the "exitFrame" callback doesn't get finished, Abort it.
            if (exitOperation.Status != DispatcherOperationStatus.Completed)
            {
                exitOperation.Abort();
            }

            ComponentDispatcher.RaiseIdle();
        }

        private static object ExitFrame(object state)
        {
            DispatcherFrame frame = state as DispatcherFrame;

            // Exit the nested message loop.
            frame.Continue = false;
            return null;
        }

        private static readonly DispatcherOperationCallback exitFrameCallback =
            new DispatcherOperationCallback(ExitFrame);

        private const int TimeoutIterationCount = TimeoutDuration / 10;
    }
}
