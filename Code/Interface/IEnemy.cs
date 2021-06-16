using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids.Abilities;
using UnityEngine;

namespace Asteroids
{
    internal interface IEnemy
    {
        public Health Health { get; set; }
        public float Attack { get; set; }
        public float Speed { get; set; }
        public int Price { get; set; }
        IAbility this[int index] { get; }
        string this[Target index] { get; }
        int MaxDamage { get; }
        IEnumerable<IAbility> GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(DamageType index);
    }
}