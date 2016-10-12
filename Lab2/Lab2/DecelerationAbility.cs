using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class DecelerationAbility : Ability
    {
        public DecelerationAbility()
        {
            this.Type = TypeAbility.Acceleration;
        }

        public override Effect BuildEffect()
        {
            Effect effect = base.BuildEffect();

            effect.DifferenceSpeed = -40;

            return effect;
        }
    }
}
