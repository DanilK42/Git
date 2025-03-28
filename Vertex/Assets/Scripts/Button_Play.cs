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
    public Animator e;
    //[SerializeField] private AudioClip _playSaund1;
    //private AudioSource _audioSource;
    //_audioSource = GetComponent<AudioSource>();
    //   _audioSource.PlayOneShot(_playSaund1, 1f);
    public GameObject gameObject2;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ���������
        _audioSource = GetComponent<AudioSource>();
        gameObject2.SetActive(false);
    }

    public void SetTransparency(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp01(alpha); // ������������ �� 0 �� 1
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
            Move.muv = false;
            _audioSource.PlayOneShot(_playSaund1, 1f);
            anima.SetTrigger("BlackWind");
            Invoke("Teleport", 1.4f);

        }
    }



    void Teleport()
    {
        StartCoroutine(FadeInMusic(5f)); // ������� ��������� ������ �� 2 �������

        cam.transform.position = gameCam.position;
        player.transform.position = GamePlayer.position;
        Move.muv = true;
        Button.gameObject.SetActive(true);
        gameObject2.SetActive(true);

    }
    IEnumerator FadeInMusic(float duration)
    {
        _audioSource.clip = _playSaund3; // ������������� ����
        _audioSource.loop = true;        // �������� ������������
        _audioSource.volume = 0f;        // �������� � ������� ���������
        _audioSource.Play();             // ��������� ���������������

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            _audioSource.volume = Mathf.Lerp(0f, 0.15f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _audioSource.volume = 0.15f; // ������������� ������ ���������
    }
}