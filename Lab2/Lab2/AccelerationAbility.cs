using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class AccelerationAbility : Ability
    {
        public AccelerationAbility()
        {
            this.Type = TypeAbility.Acceleration;
        }

        public override Effect BuildEffect()
        {
            Effect effect = base.BuildEffect();

            effect.DifferenceSpeed = 20;

            return effect;
        }
    }
}
