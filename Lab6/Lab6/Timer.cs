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

        public Period StartPeriod()
        {
            stopWatch.Start();
            return new Period(stopWatch);
        }

        public Period ContinuePeriod()
        {
            stopWatch.Start();
            return new Period(stopWatch);
        }

        public class Period : IDisposable
        {
            private Stopwatch stopWatch;

            public Period(Stopwatch stopWatch)
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
