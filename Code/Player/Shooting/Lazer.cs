using UnityEngine;

namespace Asteroids
{
    public class Lazer : MonoBehaviour, IAmmunition
    {
        public float speed = 10;
        public int damage = 15;
        public float timeToDes = 2.5f;
        private Rigidbody _rigidBody;
        public Rigidbody Rigidbody => _rigidBody;
        public float TimeToDestroy => timeToDes;
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            _rigidBody.AddForce(transform.forward * speed, ForceMode.Impulse);
            Destroy(gameObject, timeToDes);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}