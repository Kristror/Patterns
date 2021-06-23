using Asteroids.Abilities;
using Asteroids.Prototype;
using System;
using System.Collections.Generic;

namespace Asteroids
{
    [Serializable]
    public class Satellite : Enemy
    {
        private void Start()
        {
            var abilities = new List<IAbility>
            {
                new Ability("Dash", 100, Target.Unit, DamageType.Magical),
                new Ability("Explosion", 400, Target.None, DamageType.Magical),
            };
            SetAbilities(abilities);
        }
        public Satellite Revive()
        {
            return this.DeepCopy();
        }
    }
}