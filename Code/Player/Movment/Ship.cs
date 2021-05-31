using UnityEngine;

namespace Asteroids
{
    public sealed class Ship : IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        public float Speed => _moveImplementation.Speed;

        public Ship(IMove moveImplementation, IRotation rotationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        public void Move(Vector3 forward, float Vertical, float deltaTime)
        {
            _moveImplementation.Move(forward, Vertical, deltaTime);
        }

        public void Rotate(float Horizontal)
        {
            _rotationImplementation.Rotate(Horizontal);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}