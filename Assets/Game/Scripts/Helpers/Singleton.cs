using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
   private static T _instance;

   public static T Instace
   {
      get
      {
         return _instance;
      }
   }

   public void Awake()
   {
      _instance = (T) (object) this;
   }
}
