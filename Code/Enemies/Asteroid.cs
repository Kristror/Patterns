using Asteroids.Abilities;
using System;
using System.Collections.Generic;

namespace Asteroids
{
    [Serializable]
    public sealed class Asteroid : Enemy
    {
        private void Start()
        {
            var abilities = new List<IAbility>
            {
                new Ability("Splash", 100, Target.Unit, DamageType.Magical),
                new Ability("Explosion", 400, Target.None, DamageType.Magical),
            };
            SetAbilities(abilities);
        }

    }
}