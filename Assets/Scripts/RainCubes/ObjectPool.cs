using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPool<T> where T : IPoolable
    {
        [SerializeField] private Transform _containerObjects;

        private Dictionary<T, List<T>> _objects = new();

        public T GetObject(T prefab)
        {
            if (!_objects.ContainsKey(prefab))
            {
                _objects[prefab] = new List<T>();
            }

            List<T> pool = _objects[prefab];

            foreach (T obj in pool)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    obj.gameObject.SetActive(true);
                    pool.Remove(obj);
                    return obj;
                }
            }

            T newObj = GameObject.Instantiate(prefab);
            return newObj;
        }

        public void PutObgect(T prefab)
        {
            _objects[prefab].Add(prefab);
            prefab.gameObject.SetActive(false);
        }
    }
}