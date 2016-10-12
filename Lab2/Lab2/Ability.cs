using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    abstract class Ability
    {
        public TypeAbility Type { get; protected set; }

        public int Cost { get; private set; }

        protected int timeOfAction;
        protected int timeOfReload;

        protected DateTime timeOfEndOfReload;

        public bool IsAvailable
        {
            get
            {
                if (timeOfEndOfReload.CompareTo(new DateTime()) < 0)
                    return true;

                return false;
            }
        }

        public virtual Effect BuildEffect()
        {
            this.timeOfEndOfReload = new DateTime().AddMilliseconds(timeOfReload);

            return new Effect(new DateTime().AddMilliseconds(timeOfAction));
        }
    }
}
