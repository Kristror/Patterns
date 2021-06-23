using UnityEngine;

namespace Asteroids
{
    internal sealed class InfantryFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Infantry>("Enemy/Infantry"));

            enemy.DependencyInjectHealth(hp);

            return enemy;
        }
    }
}