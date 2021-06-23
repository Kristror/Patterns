using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    internal sealed class AmmunitionPool : BasePool
    { 

        private readonly Dictionary<string, HashSet<Bullet>> _ammunitionPool;

        public AmmunitionPool(int capacityPool) : base(capacityPool)
        {
            _ammunitionPool = new Dictionary<string, HashSet<Bullet>>();

            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }            
        }
        public Bullet GetAmmunition(string type)
        {
            Bullet result;
            switch (type)
            {
                case "Bullet":
                    result = GetBullet(GetListAmmunition(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }

            return result;
        }
        private HashSet<Bullet> GetListAmmunition(string type)
        {
            return _ammunitionPool.ContainsKey(type) ? _ammunitionPool[type] : _ammunitionPool[type] = new HashSet<Bullet>();
        }
        private Bullet GetBullet(HashSet<Bullet> ammunition)
        {
            var ammo = ammunition.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (ammo == null)
            {
                var model = Resources.Load<Bullet>("Bullet");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(model);
                    ReturnToPool(instantiate.transform);
                    ammunition.Add(instantiate);
                }

                GetBullet(ammunition);
            }
            ammo = ammunition.FirstOrDefault(a => !a.gameObject.activeSelf);
            return ammo;
        }
    }
}