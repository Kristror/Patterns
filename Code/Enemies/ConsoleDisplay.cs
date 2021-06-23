using UnityEngine;

namespace Asteroids.Visitor
{
    public sealed class ConsoleDisplay : IActiveEnemy
    {
        public void Visit(Enemy hit)
        {
            Debug.Log($"{nameof(Enemy)} is activeated");
        }
    }
}