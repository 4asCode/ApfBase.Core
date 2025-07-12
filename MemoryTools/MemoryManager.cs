using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTools
{
    public class MemoryManager
    {
        public static void CompactMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var process = Process.GetCurrentProcess();
            process.MinWorkingSet = process.MinWorkingSet;
            process.MaxWorkingSet = process.MaxWorkingSet;
        }
    }
}
