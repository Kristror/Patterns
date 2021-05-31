using UnityEngine;

namespace Asteroids
{
    internal sealed class SatelliteFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Satellite>("Enemy/Satellite"));

            enemy.DependencyInjectHealth(hp);

            return enemy;
        }
    }
}