using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
   public PauseManager PauseManager;
   private CharacterController _character;

   public CharacterController Character
   {
      get
      {
         return _character;
      }
   }
   
   public Vector3 _direction;

   public float ForwardSpeed;
   
   private int _laneOfRoad = 1;
   public float LineDistance = 4; 
   
   private void Start()
   {
      _character = GetComponent<CharacterController>();
   }

   private void Update()
   {
      _direction.z = ForwardSpeed;

      if(PauseManager.IsPause == false) PlayerDirection();
   }

   private void FixedUpdate()
   {
      _character.Move(_direction * Time.fixedDeltaTime);
   }

   public void PlayerDirection()
   {
      if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
      {
         _laneOfRoad++;
         if (_laneOfRoad == 3) _laneOfRoad = 2;
      }
      
      if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
      {
         _laneOfRoad--;
         if (_laneOfRoad == -1) _laneOfRoad = 0;
      }

      Vector3 _targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

      if (_laneOfRoad == 0)
      {
         _targetPosition += -Vector3.right * LineDistance;
      }
      else if (_laneOfRoad == 2)
      {
         _targetPosition += Vector3.right * LineDistance;
      }

      transform.position = Vector3.Lerp(transform.position, _targetPosition, 80);
      _character.center = _character.center;
   }
}
