using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
   public PauseManager PauseManager;
   public RoadModel Road;
   private Rigidbody _rigidbody;
   private PlayerInput PlayerInput;
   
   public float ForwardSpeed;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      PlayerInput = GetComponent<PlayerInput>();
   }

   private void Update()
   {
      if(PauseManager.IsPause == false) PlayerDirection();
   }

   private void FixedUpdate()
   {
      Vector3 _forwardMove = transform.forward * ForwardSpeed * Time.fixedDeltaTime;
      _rigidbody.MovePosition(_rigidbody.position + _forwardMove);
   }

   public void PlayerDirection()
   {
      if (PlayerInput.MoveRight)
      {
         Road._laneOfRoad++;
         if (Road._laneOfRoad == 3) Road._laneOfRoad = 2;
         PlayerInput.MoveRight = false;
      }
      
      if (PlayerInput.MoveLeft)
      {
         Road._laneOfRoad--;
         if (Road._laneOfRoad == -1) Road._laneOfRoad = 0;
         PlayerInput.MoveLeft = false;
      }

      Vector3 _targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

      if (Road._laneOfRoad == 0) _targetPosition += -Vector3.right * Road.LineDistance;
      
      if (Road._laneOfRoad == 2) _targetPosition += Vector3.right * Road.LineDistance;

      transform.position = Vector3.MoveTowards(transform.position, _targetPosition, 80);
   }
}
