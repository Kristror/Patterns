using System;
using UnityEngine;

namespace Asteroids
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour
    {
        public Health _health;
        private Transform _rootPool;
        private float speed = 5;
        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
        public Health Health
        {
            get =>  _health;
            set
            {
                _health = value;
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }
            }
        }
        
        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_ENEMY);
                    _rootPool = find == null ? null : find.transform;
                }
                return _rootPool;
            }
        }
        public void ActiveEnemy(Vector3 position, Quaternion rotation, Vector3 target)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            
            gameObject.SetActive(true);
            transform.SetParent(null);
            
            transform.LookAt(target);
            _rigidBody.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.Health = hp;

            return enemy;
        }
        public static Satellite CreateSatelliteEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Satellite>("Enemy/Satellite"));

            enemy.Health = hp;

            return enemy;
        }

        public void DependencyInjectHealth(Health health)
        {
            _health = health;
        }
    }
}
