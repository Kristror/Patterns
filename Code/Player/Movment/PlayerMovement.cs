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
            var moveTransform = new AccelerationMove(gameObject.GetComponent<Rigidbody>(), _speed, _acceleration);
            var rotation = new Rotation(transform, _rotationAngle);
            _ship = new Ship(moveTransform, rotation);
        }
    }
}