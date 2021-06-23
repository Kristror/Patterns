using UnityEngine;
using System.Collections.Generic;
using Asteroids.Visitor;

namespace Asteroids
{
    public class EnemiesSpawner:MonoBehaviour
    {
        [SerializeField] List<GameObject> enemiesSpawmPoints;        
        EnemyPool _enemyPool;
        GameObject _target;
        public void SetEnemiesPool(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }
        public void SetEnemiesTarget(GameObject target)
        {
            _target = target;
        }
        
        public void SpawnEnemy(int enemiesAmount)
        {
            for (int amount = 1; amount<= enemiesAmount; amount++) 
            {
                int spawnPointNumber = Random.Range(0, enemiesSpawmPoints.Count);
                Transform spawnPoint = enemiesSpawmPoints[spawnPointNumber].transform;
                var enemy = _enemyPool.GetEnemy("Asteroid");
                enemy.ActiveEnemy(spawnPoint.position, spawnPoint.rotation, _target.transform.position);
                enemy.Activate(new ConsoleDisplay());
            }
        }
    }
}