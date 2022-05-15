using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   public Transform Player;
   public Vector3 PosCamera;

   private void Update()
   {
      transform.position = new Vector3(transform.position.x, transform.position.y, Player.position.z + PosCamera.z);
   }
}
