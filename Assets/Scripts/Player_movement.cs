﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomofPlayer = 0.9f;
    public AudioSource jump;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        
        if(Input.GetButton("Jump") && isGrounded == true)
        {
            Jump();
            jump.Play();
        }

        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }

        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }

        if(moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if(moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
       
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void PlayerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomofPlayer && rayUp.collider.name == "QuestionBox")
        {
            Destroy(rayUp.collider.gameObject);
        }
            RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if(rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomofPlayer && rayDown.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }
        if(rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomofPlayer && rayDown.collider.tag != "enemy")
        {
            isGrounded = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
