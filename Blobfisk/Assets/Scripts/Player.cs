using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 0;
    public float health { get; set; }
    [SerializeField] float playerHealth = 2;
    
    float vertical;

    Vector2 movement;
    Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;

        health = playerHealth;
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput()
    {   
        vertical = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        rigidbody.velocity = new Vector2(0f, vertical * playerSpeed);
    }

    public void ResetPlayer()
    {
        this.transform.position = new Vector2(-13, 0);

        this.health = health;
    }

}

