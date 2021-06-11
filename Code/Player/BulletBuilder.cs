using UnityEngine;

namespace Asteroids.Builder
{
    internal class BulletBuilder
    {
        protected Bullet _bullet;

        public BulletBuilder() => _bullet = Object.Instantiate(Resources.Load<Bullet>("Bullet"));

        public BulletBuilder Rigidbody(float mass) 
        {
            var component = GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            return this;
        }
        public BulletBuilder ParticleSystem(Material material)
        {
            GetOrAddComponent<ParticleSystem>();
            var component = GetOrAddComponent<ParticleSystemRenderer>();
            component.material = material;
            return this;
        }
        public BulletBuilder Name(string name)
        {
            _bullet.name = name;
            return this;
        }
        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _bullet.GetComponent<T>();
            if (!result)
            {
                result = _bullet.gameObject.AddComponent<T>();
            }
            return result;
        }

        public static implicit operator Bullet(BulletBuilder builder)
        {
            return builder._bullet;
        }
    }
}