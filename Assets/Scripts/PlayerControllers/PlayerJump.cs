using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   private PlayerMovement _playerMovement;
   
   public float JumpForce;
   public float Gravity = -20;
   
   private void Start()
   {
      _playerMovement = GetComponent<PlayerMovement>();
   }

   private void Update()
   {
      if (_playerMovement.Character.isGrounded)
      {
         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
         {
            Jump();
         }
      }
      else
      {
         _playerMovement._direction.y += Gravity * Time.deltaTime;
      }
   }

   public void Jump()
   {
      _playerMovement._direction.y = JumpForce;
   }
}
