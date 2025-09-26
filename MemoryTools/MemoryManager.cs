using Exceptions.MemoryTools;
using System;
using System.Diagnostics;

namespace MemoryTools
{
    public class MemoryManager
    {
        public static void CompactMemory()
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                var process = Process.GetCurrentProcess();
                process.MinWorkingSet = process.MinWorkingSet;
                process.MaxWorkingSet = process.MaxWorkingSet;
            }
            catch (Exception ex)
            {
                throw new MemoryException(
                    "Ошибка при принудительной сборке мусора", ex
                    );
            }
        }
    }
}
