using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public static bool muv;
    public Animator anima;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        muv = true;
    }

    void Update()
    {
        if (muv)
        {
            anima.SetBool("IsUp", false);
            anima.SetBool("IsDown", false);
            anima.SetBool("IsRight", false);
            anima.SetBool("IsLeft", false);
            anima.SetBool("IsIdl", true);

            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = moveInput * speed;

            // Обработка анимаций
            if (moveInput.magnitude > 0.1f)
            {
                anima.SetBool("IsIdl", false);

                if (Mathf.Abs(moveInput.y) > Mathf.Abs(moveInput.x))
                {
                    if (moveInput.y > 0)
                        anima.SetBool("IsUp", true);
                    else
                        anima.SetBool("IsDown", true);
                }
                else
                {
                    if (moveInput.x > 0)
                        anima.SetBool("IsRight", true);
                    else
                        anima.SetBool("IsLeft", true);
                }
            }
        }
        else
        {
            anima.SetBool("IsUp", false);
            anima.SetBool("IsDown", false);
            anima.SetBool("IsRight", false);
            anima.SetBool("IsLeft", false);
            anima.SetBool("IsIdl", true);
        }
        
    }

    void FixedUpdate()
    {
        if (muv)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }


}

