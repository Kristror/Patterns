using UnityEngine;

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(Vector3 forward, float Vertical, float deltaTime);
    }
}