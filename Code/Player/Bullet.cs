using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] public float speed = 10;
        [SerializeField] public int damage = 25;
        [SerializeField] public float timeOfDes = 2.5f;
        private Transform _rootPool;
        private Rigidbody _rb;
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
            _rb = GetComponent<Rigidbody>();
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
            _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
            Invoke("ReturnToPool", timeOfDes);
        }
        
        protected void ReturnToPool()
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;

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