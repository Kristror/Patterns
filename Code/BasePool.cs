using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class BasePool
    {
        internal readonly int _capacityPool;
        internal Transform _rootPool;

        public BasePool(int capacityPool)
        {
            _capacityPool = capacityPool;
        }

        internal void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}
