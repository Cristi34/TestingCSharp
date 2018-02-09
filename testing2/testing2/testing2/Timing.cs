using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing2
{
    public class Timing
    {
        Stopwatch Watch = new Stopwatch();
        public long ElapsedMs { get; set; }
        
        public void StopTime()
        {
            Watch.Stop();
            ElapsedMs = Watch.ElapsedMilliseconds;
        }

        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Watch = Stopwatch.StartNew();
        }        
    }
}