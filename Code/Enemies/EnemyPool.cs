using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public sealed class EnemyPool :BasePool
    {
        private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;

        public EnemyPool(int capacityPool) :base(capacityPool)
        {            
            _enemyPool = new Dictionary<string, HashSet<Enemy>>();
            
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_ENEMY).transform;
            }
        }

        public Enemy GetEnemy(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }

            return result;
        }

        public HashSet<Enemy> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
        }

        private Enemy GetAsteroid(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                var model = Resources.Load<Asteroid>("Enemy/Asteroid");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(model);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }

                GetAsteroid(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }
    }
}