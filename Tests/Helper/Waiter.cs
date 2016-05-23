using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Helper
{
    internal class Waiter
    {
        public static void Until(Func<bool> condition)
        {
            for (int i = 0; i < 10; i++)
            {
                if (condition())
                {
                    return;
                }

                Task.Delay(500).Wait();
            }

            Assert.Fail("Wait until timed out.");
        }
    }
}
