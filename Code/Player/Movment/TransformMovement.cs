using UnityEngine;

namespace Asteroids
{
    public class TransformMovement : Movement
    {
        private readonly Transform _player;
        
        public TransformMovement(GameObject player, float speed): base(player,speed)
        {
            _player = player.transform;
        }

        public override void ChangeMovement(Ship ship)
        {
            ship._moveImplementation = new RigidBodyMovement(playerGameobject, Speed);
        }

        public override void Move(Vector3 forward, float Vertical, float deltaTime)
        {
            var speedOnTime = deltaTime * Speed;
            forward *= Vertical * speedOnTime;
            _player.position += forward;
        }
    }
}