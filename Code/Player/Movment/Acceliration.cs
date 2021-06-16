using UnityEngine;

namespace Asteroids
{
    internal sealed class AccelerationMove : IAccelerate
    {
        public float _acceleration;
        private readonly IMove _movement;

        public float Acceleration
        {
            get => _acceleration;
            set
            {
                if (value > 0)
                {
                    _acceleration = value;
                }
            }
        }


        public AccelerationMove(IMove movement, float acceleration)
        {
            _movement = movement;
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            _movement.Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            _movement.Speed -= _acceleration;
        }
    }
}