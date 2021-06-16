using UnityEngine;

namespace Asteroids
{
    public class RigidBodyMovement : IMove
    {
        public float Speed { get; set; }
        private readonly Rigidbody _rigidbody;
        public RigidBodyMovement(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            this.Speed = speed;
        }

        public void Move(Vector3 forward, float Vertical, float deltaTime)
        {
            var speedOnTime = deltaTime * Speed;
            forward.z += Vertical * speedOnTime;
            _rigidbody.AddRelativeForce(forward);
        }
    }
}