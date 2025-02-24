using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Exit : MonoBehaviour
{
    private bool isPlayerInTrigger;
    
    public Animator anima;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip _playSaund1;
    private AudioSource _audioSource;
    public Animator e;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetTransparency(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp01(alpha); // Ограничиваем от 0 до 1
        spriteRenderer.color = color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            e.SetBool("isOpen", true);
            isPlayerInTrigger = true;
            SetTransparency(1f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            e.SetBool("isOpen", false);
            isPlayerInTrigger = false;
            SetTransparency(0.5f);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {

            _audioSource.PlayOneShot(_playSaund1, 1f);
            ButExit();

        }
    }

    public void ButExit()
    {
        Move.muv = false;
        anima.SetTrigger("BlackWind");
        Invoke("ExitGame", 1.4f);
    }

    public void ExitGame()
    {
        Application.Quit(); 
        Debug.Log("Игра закрыта"); 
    }
}