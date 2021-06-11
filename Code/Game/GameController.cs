using UnityEngine;
using Asteroids.ServiceLocators;

namespace Asteroids
{
    public class GameController : MonoBehaviour
    {
        private const int EnemyAmount = 20;
        InputController _inputController;
        EnemyPool _enemyPool;
        EnemiesSpawner _enemiesSpawner;

        private void Start()
        {
            var player = Object.FindObjectOfType<PlayerMovement>();
            _inputController = new InputController(player.GetComponent<PlayerMovement>().Ship, player.transform, player.GetComponent<Shooting>());
            _enemyPool = new EnemyPool(EnemyAmount);
            _enemiesSpawner = Object.FindObjectOfType<EnemiesSpawner>();
            _enemiesSpawner.SetEnemiesPool(_enemyPool);
            _enemiesSpawner.SetEnemiesTarget(player.gameObject);

            _enemiesSpawner.SpawnEnemy(1);

            ServiceLocator.SetService<EnemyPool>(_enemyPool);
            
        }
        private void Update()
        {
            _inputController.Execute();
        }
    }
}
