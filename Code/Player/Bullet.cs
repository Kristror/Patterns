using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 10;
        public int damage = 25;
        public float timeOfDes = 2.5f;
        private Transform _rootPool;
        private Rigidbody _rigidBody;
        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rootPool = find == null ? null : find.transform;
                }
                return _rootPool;
            }
        }
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<IEntity>().TakeDamage(damage);
                ReturnToPool();
            }
        }
        public void ActiveBullet(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
            _rigidBody.AddForce(transform.forward * speed, ForceMode.Impulse);
            Invoke("ReturnToPool", timeOfDes);
        }
        
        protected void ReturnToPool()
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }
    }
}