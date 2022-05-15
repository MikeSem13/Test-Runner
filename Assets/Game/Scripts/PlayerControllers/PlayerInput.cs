using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  private PlayerMovement _playerMovement;

  private void Start()
  {
    _playerMovement = GetComponent<PlayerMovement>();
  }

  public bool MoveRight;
  public bool MoveLeft;
  public bool Jump;

  private void Update()
  {
    MoveLeft = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);

    MoveRight = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);

    Jump = Input.GetKeyDown(KeyCode.Space);
  }
}
