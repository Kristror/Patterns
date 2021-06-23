using UnityEngine;

namespace Asteroids
{
    public abstract class Weapon : IShoot
    {
        internal Transform _bulletStartPos;
        internal AudioClip _audioClip;
        internal AudioSource _audioSource;

        public Weapon(Transform bulletStartPos, AudioSource audioSource, AudioClip audioClip)
        {
            _bulletStartPos = bulletStartPos;
            _audioSource = audioSource;
            _audioClip = audioClip;
        }
        
        public void SetBulletStartPosition(Transform bulletStartPos)
        {
            _bulletStartPos = bulletStartPos;
        }
        public void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }
        public void SetAudioSource(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public abstract void Shoot();
    }
}