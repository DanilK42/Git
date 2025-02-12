using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public static bool muv;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        muv = true;
    }


    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput * speed;

    }

    void FixedUpdate()
    {
        if (muv == true)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
       
    }

}

