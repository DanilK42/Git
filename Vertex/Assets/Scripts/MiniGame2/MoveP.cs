using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MoveP : MonoBehaviour
{
    public float speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    public int chet = 0;
    [SerializeField] private Text scoreText;
    public GameObject teleport;
    public static bool Game;
    [SerializeField] private AudioClip _playSaund1;
    private AudioSource _audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();
        teleport.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput * speed;

        if(chet == 3)
        {
            teleport.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (Game)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            _audioSource.PlayOneShot(_playSaund1, 1f);
            Destroy(collision.gameObject);
            chet++;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = chet + " из 3";
        }
    }


}
