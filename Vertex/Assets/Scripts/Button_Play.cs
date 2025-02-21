using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;
using UnityEngine.UI;
public class Button_Play : MonoBehaviour
{
    private bool isPlayerInTrigger;
    public Camera cam;
    public Transform gameCam;
    public Transform GamePlayer;
    public GameObject player;
    public Animator anima;
    private SpriteRenderer spriteRenderer;
    public Image Button;
    [SerializeField] private AudioClip _playSaund3;
    [SerializeField] private AudioClip _playSaund1;
    private AudioSource _audioSource;

    //[SerializeField] private AudioClip _playSaund1;
    //private AudioSource _audioSource;
    //_audioSource = GetComponent<AudioSource>();
      //   _audioSource.PlayOneShot(_playSaund1, 1f);

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
            isPlayerInTrigger = true;
            SetTransparency(1f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            SetTransparency(0.5f);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {

            _audioSource.PlayOneShot(_playSaund1, 1f);
            Move.muv = false;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport", 1.4f);

        }
    }



    void Teleport()
    {
        StartCoroutine(FadeInMusic(5f)); // Плавное появление музыки за 2 секунды

        cam.transform.position = gameCam.position;
        player.transform.position = GamePlayer.position;
        Move.muv = true;
        Button.gameObject.SetActive(true);

    }
    IEnumerator FadeInMusic(float duration)
    {
        _audioSource.clip = _playSaund3; // Устанавливаем клип
        _audioSource.loop = true;        // Включаем зацикливание
        _audioSource.volume = 0f;        // Начинаем с нулевой громкости
        _audioSource.Play();             // Запускаем воспроизведение

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            _audioSource.volume = Mathf.Lerp(0f, 0.15f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _audioSource.volume = 0.15f; // Устанавливаем полную громкость
    }
}