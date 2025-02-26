using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public static bool muv;
    public static bool muv2;
    public Animator anima;
    [SerializeField] private AudioClip _playSaund;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        muv = true;
        muv2 = true;
    }

    private void PleySoundStep ()
    {
        _audioSource.PlayOneShot(_playSaund,1f);
    }

    void Update()
    {
        if (muv && muv2)
        {
            // ������� ���������� ��� ��������
            anima.SetBool("IsUp", false);
            anima.SetBool("IsDown", false);
            anima.SetBool("IsRight", false);
            anima.SetBool("IsLeft", false);
            anima.SetBool("IsIdl", true);

            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = moveInput * speed;

            // ���� �������� ����, ������������ ��������
            if (moveInput.magnitude > 0.1f)
            {
                anima.SetBool("IsIdl", false);

                // ���������� ����������� ��������
                if (Mathf.Abs(moveInput.y) > Mathf.Abs(moveInput.x))
                {
                    // ���� �������� ������ �� ��� Y, �������� ��������������� ��������
                    if (moveInput.y > 0)
                        anima.SetBool("IsUp", true);
                    else
                        anima.SetBool("IsDown", true);
                }
                else
                {
                    // ���� �������� ������ �� ��� X, �������� ��������������� ��������
                    if (moveInput.x > 0)
                        anima.SetBool("IsRight", true);
                    else
                        anima.SetBool("IsLeft", true);
                }
            }
        }
        else
        {
            // ���� �������� ���������, ������������� Idle ��������
            anima.SetBool("IsUp", false);
            anima.SetBool("IsDown", false);
            anima.SetBool("IsRight", false);
            anima.SetBool("IsLeft", false);
            anima.SetBool("IsIdl", true);
        }
    }

    void FixedUpdate()
    {
        if (muv && muv2)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }


}

