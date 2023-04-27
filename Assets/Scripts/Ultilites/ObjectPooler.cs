using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ultilites
{
    [Serializable]
    public class PoolInfo
    {
        public int amount;
        public GameObject prefab;
        public GameObject container;
    
        public List<GameObject> pool = new List<GameObject>();
    }

    public class ObjectPooler : Singleton<ObjectPooler>
    {
        [SerializeField]
        private List<PoolInfo> listOfPool;

        private void Start()
        {
            for (int i = 0; i < listOfPool.Count; i++)
            {
                FillPool(listOfPool[i]);
            }
        }

        private void FillPool(PoolInfo info)
        {
            for (int i = 0; i < info.amount; i++)
            {
                GameObject objInstance = Instantiate(info.prefab, info.container.transform);
                objInstance.name = info.prefab.name;
                objInstance.SetActive(false);
                info.pool.Add(objInstance);
            }
        }

        public GameObject GetPooledObject(GameObject obj)
        {
            PoolInfo selected = GetPoolByType(obj);

            GameObject objInstance;
            if (selected.pool.Count > 0)
            {
                objInstance = selected.pool[^1];
                selected.pool.Remove(objInstance);
            }
            else
            {
                objInstance = Instantiate(selected.prefab, selected.container.transform);
                objInstance.name = selected.prefab.name;
            }
            return objInstance;
        }

        public void CoolObject(GameObject obj)
        {
            obj.SetActive(false);
        
            PoolInfo selected = GetPoolByType(obj);
        
            if(!selected.pool.Contains(obj))
                selected.pool.Add(obj);
        }

        private PoolInfo GetPoolByType(GameObject obj)
        {
            foreach (var t in listOfPool)
            {
                if (obj.name == t.prefab.name)
                    return t;
            }

            Debug.LogError("does not exist PoolObject's "+ obj.name+". Create it in ObjectPooler!");
            return null;
        }
    }
}