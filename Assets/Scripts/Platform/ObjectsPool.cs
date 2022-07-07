using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public sealed class ObjectsPool<T> where T : MonoBehaviour
    {
        private readonly List<T> _objects = new();
        private int _count;

        public void Add(int count, T prefab, Transform parent = null)
        {
            if (!_objects.Contains(prefab))
            {
                _count = count;
                for (int i = 0; i < count; i++)
                {
                    var createObject = Object.Instantiate(prefab, parent);
                    createObject.gameObject.SetActive(false);
                    _objects.Add(createObject.GetComponent<T>());
                }
            }
        }

        private int GetIndex()
        {
            for (int i = 0; i < _objects.Count - 1; i++)
            {
                if (!_objects[i].gameObject.activeInHierarchy)
                {
                    return i;
                }
            }
            return 0;
        }
        public T Get(T prefab)
        {
            if (HaveObjects(_objects))
            {
                int index = GetIndex();
                return _objects[index];
            }
            else
            {
                Add(_count, prefab);
                return _objects[GetIndex()];
            }
        }

        private bool HaveObjects(List<T> objects)
        {
            for (int i = 0; i < objects.Count - 1; i++)
            {
                if (!objects[i].gameObject.activeInHierarchy)
                    return true;
            }
            return false;
        }
    }
}