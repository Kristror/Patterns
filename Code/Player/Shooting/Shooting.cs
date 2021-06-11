using UnityEngine;
using Asteroids.Proxy.ProxyProtection;
using Asteroids.Modifications;

namespace Asteroids 
{
    public class Shooting : MonoBehaviour, IShoot
    {
        [SerializeField] private Transform _bulletStartPos;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;
        [SerializeField] private GameObject _scope;
        private ModificationWeapon _modificationWeapon;
        private UnlockWeapon _unlockWeapon;
        private AudioSource _audioSource;
        private Camera _camera;
        private IShoot _shootingImplementation;

        public void Awake()
        {
            _audioSource = _bulletStartPos.gameObject.GetComponent<AudioSource>();
            _unlockWeapon = new UnlockWeapon(true);
            _camera = Camera.main;
            ChangeToBullets();
            ApplyMuffler();
            DeleteMuffler();
            ApplyScope();
            DeleteScope();
            LockWeapon();
        }

        public void ApplyMuffler()
        {
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPositionMuffler, _muffler);
            _modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            _modificationWeapon.ApplyModification((Weapon)_shootingImplementation);
            _shootingImplementation = _modificationWeapon;
        }

        public void DeleteMuffler()
        {
            _modificationWeapon.DeleteModification();
            ChangeToBullets();
        }
        public void ApplyScope()
        {
            var scope = new Scope(30f, _scope);
            _modificationWeapon = new ModificationScope(_camera,scope);
            _modificationWeapon.ApplyModification((Weapon)_shootingImplementation);
            _shootingImplementation = _modificationWeapon;
        }

        public void DeleteScope()
        {
            _modificationWeapon.DeleteModification();
            ChangeToBullets();
        }
        public void LockWeapon()
        {
            _shootingImplementation = new WeaponProxy(_shootingImplementation, _unlockWeapon);
        }

        public void ChangeToBullets()
        {
            _shootingImplementation = new BulletShooting(_bulletStartPos, _audioSource, _audioClip);
            
        }
        public void ChangeToLazer()
        {
            _shootingImplementation = new LazerShooting(_bulletStartPos, _audioSource, _audioClip);
        }

        public void Shoot()
        {
            _shootingImplementation.Shoot();
        }
    }
}