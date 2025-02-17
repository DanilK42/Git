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
            // Сначала сбрасываем все анимации
            anima.SetBool("IsUp", false);
            anima.SetBool("IsDown", false);
            anima.SetBool("IsRight", false);
            anima.SetBool("IsLeft", false);
            anima.SetBool("IsIdl", true);

            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = moveInput * speed;

            // Если движение есть, обрабатываем анимацию
            if (moveInput.magnitude > 0.1f)
            {
                anima.SetBool("IsIdl", false);

                // Определяем направление движения
                if (Mathf.Abs(moveInput.y) > Mathf.Abs(moveInput.x))
                {
                    // Если движение больше по оси Y, включаем соответствующую анимацию
                    if (moveInput.y > 0)
                        anima.SetBool("IsUp", true);
                    else
                        anima.SetBool("IsDown", true);
                }
                else
                {
                    // Если движение больше по оси X, включаем соответствующую анимацию
                    if (moveInput.x > 0)
                        anima.SetBool("IsRight", true);
                    else
                        anima.SetBool("IsLeft", true);
                }
            }
        }
        else
        {
            // Если движение выключено, устанавливаем Idle анимацию
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

