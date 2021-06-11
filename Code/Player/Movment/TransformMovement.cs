using UnityEngine;

namespace Asteroids
{
    public class TransformMovement : IMove
    {
        public float Speed { get; set; }
        private readonly Transform _player;
        public TransformMovement(Transform player, float speed)
        {
            _player = player;
            this.Speed = speed;
        }

        public void Move(Vector3 forward, float Vertical, float deltaTime)
        {
            var speedOnTime = deltaTime * Speed;
            forward *= Vertical * speedOnTime;
            _player.position +=  forward;
        }
    }
}