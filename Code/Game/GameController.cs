using UnityEngine;
using Asteroids.UI;
using Asteroids.PlayerModifications;

namespace Asteroids
{
    public class GameController : MonoBehaviour
    {
        private const int EnemyAmount = 20;
        [SerializeField] private Canvas _GameUI;
        [SerializeField] private Canvas _PauseMenu;
        InputController _inputController;
        EnemyPool _enemyPool;
        EnemiesSpawner _enemiesSpawner;
        UISystem _UISystem;

        private void Start()
        {
            var player = Object.FindObjectOfType<PlayerMovement>();
            _inputController = new InputController(player.GetComponent<PlayerMovement>().Ship, player.transform, player.GetComponent<Shooting>());

            PlayerModifier playerModifier = new PlayerModifier(player.GetComponent<Player>());
            playerModifier.Add(new AddDefenseModifier(player.GetComponent<Player>(), 10));
            playerModifier.Add(new AddMaxHealthModifier(player.GetComponent<Player>(), 50));

            playerModifier.Handle();

            _UISystem = new UISystem(_GameUI, _PauseMenu);
            _inputController.SetUISystem(_UISystem);
            
            _enemyPool = new EnemyPool(EnemyAmount);
            _enemyPool.SetEnemiesDeathAction(_UISystem.EnemyDeath);
            _enemiesSpawner = Object.FindObjectOfType<EnemiesSpawner>();
            _enemiesSpawner.SetEnemiesPool(_enemyPool);
            _enemiesSpawner.SetEnemiesTarget(player.gameObject);
            _enemiesSpawner.SpawnEnemy(1);
        }
        private void Update()
        {
            _inputController.Execute();
        }
    }
}
