using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiAwaitableWinforms
{
    internal static class ClassInClassLib
    {
        internal static async Task DoSomethingAsync()
        {
            await Task.Delay(1000).ConfigureAwait(false);
        }

        internal static async Task DoSomethingAsync(bool awaitableConfig)
        {
            await Task.Delay(1000).ConfigureAwait(awaitableConfig);
        }

        internal static async Task DoSomethingSyncAsynchronously(bool awaitableConfig)
        {
            await Task.Run(() => {
                Debug.WriteLine("Before thread sleep");
                Thread.Sleep(1000);
                Debug.WriteLine("After thread sleep");
            }).ConfigureAwait(awaitableConfig);
        }
    }
}
