using UnityEngine;

namespace Asteroids
{
    internal sealed class MagFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Mag>("Enemy/Mag"));

            enemy.DependencyInjectHealth(hp);

            return enemy;
        }
    }
}