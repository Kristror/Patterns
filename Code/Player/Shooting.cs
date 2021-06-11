using UnityEngine;

namespace Asteroids
{
    public class Shooting : MonoBehaviour, IShoot
    {
        private const int BulletsAmount = 25;
        [SerializeField] private Transform _BulletStartPos;
        private AmmunitionPool _ammunitionPool;
        private void Start()
        {
            _ammunitionPool = new AmmunitionPool(BulletsAmount);
        }
        public void Shoot()
        {
            var bullet = _ammunitionPool.GetAmmunition("Bullet");
            bullet.ActiveBullet(_BulletStartPos.position, _BulletStartPos.rotation);
        }
    }
}