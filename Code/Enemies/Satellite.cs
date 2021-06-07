using Asteroids.Prototype;
using System;

namespace Asteroids
{
    [Serializable]
    public class Satellite : Enemy
    {
        public Satellite Revive()
        {
            return this.DeepCopy();
        }
    }
}