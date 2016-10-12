using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Character
    {
        private int hitPoints;
        private int speed;
        private int mana;
        private int manaRegeneration;

        private Dictionary<TypeAbility, Ability> abilities;
        private List<Effect> effects;

        public int HitPoints
        {
            get
            {
                int result = hitPoints;

                foreach (Effect effect in effects)
                    if (effect.IsActive)
                        result += effect.DifferenceHitPoints;

                return result;
            }
        }

        public int Speed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Mana
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int ManaRegeneration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ApplyAbility(TypeAbility type, Character character)
        {
            Ability ability = abilities[type];
            mana -= ability.Cost;

            character.AddEffect(ability.BuildEffect());
        }

        public void AddAbility(Ability ability)
        {
            if (ability.IsAvailable)
                abilities.Add(ability.Type, ability);
        }

        public void AddEffect(Effect effect)
        {
            throw new NotImplementedException();
        }

        public bool CheckAvailabilityOfAbility(TypeAbility type)
        {
            throw new NotImplementedException();
        }

        public List<TypeAbility> GetAvailableAbilities()
        {
            List<TypeAbility> availableAbilities = new List<TypeAbility>();

            foreach (Ability ability in abilities.Values)
                if (ability.IsAvailable)
                    availableAbilities.Add(ability.Type);

            return availableAbilities;
        }
    }
}
