using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   private PlayerInput _playerInput;
   private Rigidbody _rigidbody;
   
   public float JumpForce;

   public bool IsGrounded;
   
   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _playerInput = GetComponent<PlayerInput>();
   }

   private void Update()
   {
      if (_playerInput.Jump && IsGrounded)
      {
         _playerInput.Jump = false;
         IsGrounded = false;
         Jump();
      }
   }

   public void Jump()
   {
      _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
   }
}
