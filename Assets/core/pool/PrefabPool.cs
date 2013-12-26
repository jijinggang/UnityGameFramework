//GameObject显示对象池管理
//未来可以加上定时器来释放长时间不用的对象

using System.Collections.Generic;
using UnityEngine;
using System.Collections;
namespace core
{
    public sealed class PrefabPool
    {
        private static PrefabPool _instance = null;
        public static PrefabPool Inst
        {
            get
            {
                if (_instance == null)
                    _instance = new PrefabPool();
                return _instance;
            }
        }

        private Dictionary<Component, Queue<Component>> _prefab2objects = new Dictionary<Component, Queue<Component>>(); 
        private Dictionary<Component, Component> _object2prefab = new Dictionary<Component, Component>();

        public void Clear()
        {
            _prefab2objects.Clear();
            _object2prefab.Clear();
        }

        private Queue<Component> getObjectsByPrefab<T>(T prefab) where T : Component
        {
            if (_prefab2objects.ContainsKey(prefab))
                return _prefab2objects[prefab];
            else
            {
                var objects = new Queue<Component>();
                _prefab2objects.Add(prefab, objects);
                return objects;
            }

        }

        public T Spawn<T>(T prefab, Vector3 position, Quaternion rotation) where T : Component
        {
            T obj = null;
            var objects = getObjectsByPrefab(prefab);
            if (objects.Count > 0)
            {
                obj = objects.Dequeue() as T;
                obj.transform.parent = null;
                obj.transform.localPosition = position;
                obj.transform.localRotation = rotation;
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj = (T)Object.Instantiate(prefab, position, rotation);
            }
            _object2prefab.Add(obj, prefab);
            return obj;
        }

        public T Spawn<T>(T prefab, Vector3 position) where T : Component
        {
            return Spawn(prefab, position, Quaternion.identity);
        }
        
        public T Spawn<T>(T prefab) where T : Component
        {
            return Spawn(prefab, Vector3.zero, Quaternion.identity);
        }

        public void Recycle<T>(T obj) where T : Component
        {
            if (_object2prefab.ContainsKey(obj))
            {
                var prefab = _object2prefab[obj];
                var objects = getObjectsByPrefab(prefab);
                objects.Enqueue(obj);
                _object2prefab.Remove(obj);
                obj.transform.parent = null;
                obj.gameObject.SetActive(false);
            }
            else
                Object.Destroy(obj.gameObject);
        }

        public int Count<T>(T prefab) where T : Component
        {
            if (_prefab2objects.ContainsKey(prefab))
                return _prefab2objects[prefab].Count;
            else
                return 0;
        }
    }

    public static class PrefabPoolHelper
    {
        public static T Spawn<T>(this T prefab, Vector3 position, Quaternion rotation) where T : Component
        {
            return PrefabPool.Inst.Spawn(prefab, position, rotation);
        }

        public static T Spawn<T>(this T prefab, Vector3 position) where T : Component
        {
            return PrefabPool.Inst.Spawn(prefab, position, Quaternion.identity);
        }

        public static T Spawn<T>(this T prefab) where T : Component
        {
            return PrefabPool.Inst.Spawn(prefab, Vector3.zero, Quaternion.identity);
        }

        public static void Recycle<T>(this T obj) where T : Component
        {
            PrefabPool.Inst.Recycle(obj);
        }

        public static int Count<T>(T prefab) where T : Component
        {
            return PrefabPool.Inst.Count(prefab);
        }
    }
}
