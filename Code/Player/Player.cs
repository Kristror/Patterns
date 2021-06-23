using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private float _defense;
        private void Awake()
        {
            _health = new Health(100);
        }

        public Health Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health.Current <= 0.0f)
                {
                    Death();
                };
            }
        }
        public float Defense
        {
            get => _defense;
            set { _defense = value; }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(10); //change when add enemies
            }
        }
        public void TakeDamage(float damage)
        {
            if(Defense <damage)
                Health.ChangeCurrentHealth(Health.Current - damage + Defense);
        }
        public void Death()
        {
            Destroy(gameObject);
        }
    }
}