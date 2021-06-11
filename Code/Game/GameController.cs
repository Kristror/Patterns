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
            UnitFactory unitFactory = new UnitFactory();           
            Enemy[] enemies = unitFactory.UnitsFromFile("D:/Загрузки/Учеба/Geek/Unity/Asteroids/Assets/Files/Units.json");
        }
        private void Update()
        {
            _inputController.Execute();
        }
    }
}
