using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Setting : MonoBehaviour
{
    private bool isPlayerInTrigger;
    
    
    public Animator anima;
    private SpriteRenderer spriteRenderer;
    public bool clouseGame;
    public GameObject checkButton;
    public Image image;
    public Animator DoskaAnim;
    public GameObject TenLeval;
    [SerializeField] private AudioClip _playSaund1;
    private AudioSource _audioSource;
    public Animator e;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент
        TenLeval.SetActive(true);
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && clouseGame == true)
        {
            _audioSource.PlayOneShot(_playSaund1, 1f);
            Collider2D targetCollider = checkButton.GetComponent<Collider2D>();
            targetCollider.enabled = true;
            Move.muv = true;
            anima.SetTrigger("BlackWind");
            Invoke("OnEnabl", 1.3f);
            clouseGame = false;
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && clouseGame == false)
        {
            _audioSource.PlayOneShot(_playSaund1, 1f);
            Collider2D targetCollider = checkButton.GetComponent<Collider2D>();
            targetCollider.enabled = false;
            Move.muv = false;
            anima.SetTrigger("BlackWind");
            Invoke("Setting", 1.3f);
            clouseGame = true;
        }
    }
    void Setting ()
    {
        DoskaAnim.SetBool("IsOpen", true);
        image.gameObject.SetActive(true);
    }
    void OnEnabl ()
    {
        DoskaAnim.SetBool("IsOpen", false);
        image.gameObject.SetActive(false);
    }
}
