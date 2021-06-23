using UnityEngine;

namespace Asteroids
{
    public class RigidBodyMovement : Movement
    {
        private readonly Rigidbody _rigidbody;
        public RigidBodyMovement(GameObject player, float speed) :base (player,speed)
        {
            _rigidbody = player.GetComponent<Rigidbody>();
        }
        public override void ChangeMovement(Ship ship)
        {
            ship._moveImplementation = new TransformMovement(playerGameobject, Speed);
        }

        public override void Move(Vector3 forward, float Vertical, float deltaTime)
        {
            var speedOnTime = deltaTime * Speed;
            forward.z += Vertical * speedOnTime;
            _rigidbody.AddRelativeForce(forward);
        }
    }
}