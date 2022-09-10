using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int BasePower = 100;

        public Warrior(string name)
            : base(name, BasePower)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {base.Name} hit for {base.Power} damage";
        }
    }
}
