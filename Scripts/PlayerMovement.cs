using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float horizontal;
    public float vertical;
    public float speed = 5f;
    private Vector2 pos = new Vector2(0,-1f);
    private float moveLimiter = 0.7f;
    private float isMoving = -1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical",vertical);
        anim.SetFloat("isMoving",isMoving);
        if (horizontal != 0 || vertical != 0)
        {
            pos = new Vector2(horizontal,vertical);
            isMoving = 1f;
        }

        else 
        {
            isMoving = -1f;
            anim.SetFloat("horizontal",pos.x);
            anim.SetFloat("vertical",pos.y);
        }
    }
  
    void FixedUpdate()
    {

         if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        rb.velocity = new Vector2(horizontal * speed , vertical * speed);
    }
}
