using UnityEngine;

namespace Asteroids
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _rotationAngle;

        private Ship _ship;

        public Ship Ship => _ship;

        private void Awake()
        {            
            var moveTransform = new TransformMovement(gameObject, _speed);
            var rotation = new Rotation(transform, _rotationAngle);
            var acceleration = new AccelerationMove(moveTransform, _acceleration);

            _ship = new Ship(moveTransform, rotation, acceleration);
        }
    }
}