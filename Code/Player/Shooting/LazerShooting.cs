using UnityEngine;

namespace Asteroids
{
    public class LazerShooting : Weapon
    {
        public LazerShooting(Transform bulletStartPos, AudioSource audioSource, AudioClip audioClip) : base(bulletStartPos, audioSource, audioClip)
        {
        }
        public override void Shoot()
        {
            Object.Instantiate(Resources.Load<Lazer>("Lazer"), _bulletStartPos.position, _bulletStartPos.rotation);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}