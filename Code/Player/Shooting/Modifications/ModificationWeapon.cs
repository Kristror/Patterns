using UnityEngine;

namespace Asteroids.Modifications
{
    internal abstract class ModificationWeapon : IShoot
    {
        private Weapon _weapon;

        protected abstract Weapon AddModification(Weapon weapon); 
        protected abstract void RemoveModification();

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }
        public void DeleteModification()
        {
            RemoveModification();
        }

        public void Shoot()
        {
            _weapon.Shoot();
        }
    }
}