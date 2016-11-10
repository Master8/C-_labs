using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Lab6
{
    class Timer
    {
        private Stopwatch stopWatch = new Stopwatch();

        public long ElapsedMilliseconds
        {
            get
            {
                return stopWatch.ElapsedMilliseconds;
            }
        }

        public TimerToken Start()
        {
            stopWatch.Start();
            return new TimerToken(stopWatch);
        }

        public TimerToken Continue()
        {
            stopWatch.Start();
            return new TimerToken(stopWatch);
        }

        public class TimerToken : IDisposable
        {
            private Stopwatch stopWatch;

            public TimerToken(Stopwatch stopWatch)
            {
                this.stopWatch = stopWatch;
            }

            public void Dispose()
            {
                stopWatch.Stop();
            }
        }
    }
}
