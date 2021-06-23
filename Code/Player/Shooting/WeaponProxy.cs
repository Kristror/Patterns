using UnityEngine;

namespace Asteroids.Proxy.ProxyProtection
{
    public sealed class WeaponProxy : IShoot
    {
        private readonly IShoot _weapon;
        private readonly UnlockWeapon _unlockWeapon;

        public WeaponProxy(IShoot weapon, UnlockWeapon unlockWeapon)
        {
            _weapon = weapon;
            _unlockWeapon = unlockWeapon;
        }

        public IShoot GetWeapon()
        {
            return _weapon;
        }

        public void Shoot()
        {
            if (_unlockWeapon.IsUnlock)
            {
                _weapon.Shoot();
            }
        }
    }
}