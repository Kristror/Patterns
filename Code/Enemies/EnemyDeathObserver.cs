using UnityEngine;
using System.Collections.Generic;
using System;

namespace Asteroids.Observer
{
    public sealed class EnemyDeathObsever
    {
        private Action<string, int> EnemyDeath;

        public EnemyDeathObsever(Action<string, int> onDeath)
        {
            EnemyDeath = onDeath;
        }
        public void Add(HashSet<Enemy> enemies)
        {
            foreach(Enemy enemy in enemies)
            {
                Add(enemy);
            }
        }

        public void Add(Enemy enemy)
        {
            enemy._onDeath += EnemyDeath;
        }

        public void Remove(Enemy enemy)
        {
            enemy._onDeath += EnemyDeath;
        }
    }
}