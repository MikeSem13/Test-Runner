
using System;
using UnityEngine;

public class PlayerObstacleDetector : MonoBehaviour
{
    private PlayerJump _playerJump;

    private void Start()
    {
        _playerJump = GetComponent<PlayerJump>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground") _playerJump.IsGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin") Destroy(other.gameObject);
    }

    public bool IsGameover = false;
}
