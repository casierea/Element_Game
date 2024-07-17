using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// controls player movement
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; 
    

    // dash stuff 
    public float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength;
    public float dashCooldown;
    // dash stuff

    private Vector2 direction;
    private Rigidbody2D rb;
    private float dashCounter;
    private float dashCooldownCounter;

    private void Start() 
    {
        activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // updates player each tick
    void Update()
    {
        TakeInput();
        Move();
    }
    
    // moves player
    private void Move() 
    {
      // Normalize direction to prevent faster movement when moving diagonally
      direction = direction.normalized;
        transform.Translate(direction * activeMoveSpeed * Time.deltaTime);
    }

    // takes in input from player
    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (dashCooldownCounter <= 0 && dashCounter <= 0) 
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0) 
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0 )
            {
                activeMoveSpeed = moveSpeed;
                dashCooldownCounter = 3; // hardcoded for now, will fix later :)
            }
        }

        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }
    }
}
