using UnityEngine;

namespace Asteroids
{
    public abstract class Movement : IMove
    {
        public float Speed { get; set; }
        public GameObject playerGameobject;
        public Movement(GameObject player, float speed)
        {
            playerGameobject = player;
            Speed = speed;
        }

        public abstract void ChangeMovement(Ship ship);

        public abstract void Move(Vector3 forward, float Vertical, float deltaTime);

    }
}
