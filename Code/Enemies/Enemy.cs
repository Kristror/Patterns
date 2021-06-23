using Asteroids.Abilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Asteroids.Visitor;

namespace Asteroids
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        public Health _health;
        public float _attack;
        private Transform _rootPool;
        private float _speed = 5;
        private Rigidbody _rigidBody;
        public event Action<string,int> _onDeath;

        [SerializeField] private int _price = 100;
        private List<IAbility> _ability;


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
        public float Attack 
        {
            get => _attack;
            set { _attack = value; }
        }
        public float Speed
        {
            get => _speed;
            set { _speed = value; }
        }
        public int Price
        {
            get => _price;
            set { _price = value; }
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
        public void SetAbilities(List<IAbility> ability)
        {
            _ability = ability;
        }
        public IAbility this[int index] => _ability[index];
        public string this[Target index]
        {
            get
            {
                var ability = _ability.FirstOrDefault(a => a.Target == index);
                return ability == null ? "Not supported" : ability.ToString();
            }
        }
        public int MaxDamage => _ability.Select(a => a.Damage).Max();
        public IEnumerable<IAbility> GetAbility()
        {
            while (true)
            {
                yield return _ability[UnityEngine.Random.Range(0, _ability.Count)];
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _ability.Count; i++)
            {
                yield return _ability[i];
            }
        }
        public IEnumerable<IAbility> GetAbility(DamageType index)
        {
            foreach (IAbility ability in _ability)
            {
                if (ability.DamageType == index)
                {
                    yield return ability;
                }
            }
        }
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
        public void ActiveEnemy(Vector3 position, Quaternion rotation, Vector3 target)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            
            gameObject.SetActive(true);
            transform.SetParent(null);
            
            transform.LookAt(target);
            _rigidBody.AddForce(transform.forward * _speed, ForceMode.Impulse);
        }
        public void Activate(IActiveEnemy value)
        {
            value.Visit(this);
        }
        protected void ReturnToPool()
        {
            _onDeath(this.GetType().Name,_price);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }
        public void TakeDamage(int damage)
        {
            ReturnToPool(); //только для теста потом изменю            
        }
        public void DependencyInjectHealth(Health health)
        {
            _health = health;
        }
    }
}
