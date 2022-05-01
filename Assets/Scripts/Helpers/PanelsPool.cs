using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelsPool : Singleton<PanelsPool>
{
   public List<GameObject> PrefabsForPool;

   private List<GameObject> _pooledObjects = new List<GameObject>();

   public GameObject GetGameobjectFromPool(string Name)
   {
      var instance = _pooledObjects.FirstOrDefault(obj => obj.name == Name);

      if (instance != null)
      {
         _pooledObjects.Remove(instance);
         instance.SetActive(true);
         return instance;
      }
      
      var prefab = _pooledObjects.FirstOrDefault(obj => obj.name == Name);
      if (prefab != null)
      {
         var newinstance = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
         newinstance.name = Name;
         return newinstance;
      }

      return null;
   }

   public void PoolObject(GameObject obj)
   {
      obj.SetActive(false);
      _pooledObjects.Add(obj);
   }
}
