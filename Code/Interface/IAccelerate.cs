using UnityEngine;

namespace Asteroids
{
    public interface IAccelerate
    {
        float Acceleration { get; set; }
        public void AddAcceleration();
        public void RemoveAcceleration();
    }
}
