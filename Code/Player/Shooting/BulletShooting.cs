using UnityEngine;

namespace Asteroids
{
    public class BulletShooting : Weapon
    {
        private const int bulletsAmount = 25;
        private AmmunitionPool _ammunitionPool;
        public BulletShooting(Transform bulletStartPos, AudioSource audioSource, AudioClip audioClip) : base(bulletStartPos, audioSource, audioClip)
        {
                _ammunitionPool = new AmmunitionPool(bulletsAmount);
        }
        public override void Shoot()
        {            
            var bullet = _ammunitionPool.GetAmmunition("Bullet");
            bullet.ActiveBullet(_bulletStartPos.position, _bulletStartPos.rotation);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}