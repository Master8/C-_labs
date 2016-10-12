using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Effect
    {
        public int DifferenceHitPoints { get; set; }
        public int DifferenceSpeed { get; set; }
        public int DifferenceMana { get; set; }
        public int DifferenceManaRegeneration { get; set; }

        private DateTime timeOfEndOfAction;

        public bool IsActive
        {
            get
            {
                if (timeOfEndOfAction.CompareTo(new DateTime()) < 0)
                    return false;

                return true;
            }
        }

        public Effect(DateTime timeOfEndOfAction)
        {
            this.timeOfEndOfAction = timeOfEndOfAction;
        }
    }
}
