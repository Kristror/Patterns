using UnityEngine;

namespace Asteroids
{
    public sealed class Ship : IMove, IRotation, IAccelerate
    {
        public Movement _moveImplementation;
        private readonly IAccelerate _accelirationImplementation;
        private readonly IRotation _rotationImplementation;

        public float Acceleration
        {
            get => _accelirationImplementation.Acceleration;
            set
            {
                _accelirationImplementation.Acceleration = value; 
            }
        }

        public float Speed
        {
            get => _moveImplementation.Speed;
            set
            {
                _moveImplementation.Speed = value;
            }
        }

        public Ship(Movement moveImplementation, IRotation rotationImplementation, IAccelerate accelirationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _accelirationImplementation = accelirationImplementation;
        }
        public void ChangeMovement()
        {
            _moveImplementation.ChangeMovement(this);
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
            if (_accelirationImplementation != null)
            {
                _accelirationImplementation.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if(_accelirationImplementation != null)
            {
                _accelirationImplementation.RemoveAcceleration();
            }
        }
    }
}