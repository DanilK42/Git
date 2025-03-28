using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorButton : MonoBehaviour
{
    public GameObject Box;
    public GameObject Button;
    public Animator anima;
    public Animator anima2;
    public float time;
    private bool isPlayerInTrigger = false;
    [SerializeField] private AudioClip _playSaund;
    [SerializeField] private AudioClip _playSaund2;
    [SerializeField] private AudioClip _playSaund3;
    private AudioSource _audioSource;

    public Image fillImage; // ������ �� UI Image
    private float targetFill = 0f; // ������� ������� �����
    public float fillSpeed = 0.02f; // �������� ����������

    private void Awake()
    {
        Box.SetActive(false);
        Button.SetActive(true);
        _audioSource = GetComponent<AudioSource>();
        fillImage.fillAmount = 0f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            anima2.SetBool("isOpen", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            anima2.SetBool("isOpen", false );
        }
    }

    void Update()
    {
        // ������ ����������� �������� fillAmount � targetFill
        if (fillImage.fillAmount < targetFill)
        {
            fillImage.fillAmount += fillSpeed * Time.deltaTime;
            fillImage.fillAmount = Mathf.Min(fillImage.fillAmount, targetFill);
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            anima.SetTrigger("ElevatorButton");
            Move.muv = false;
            _audioSource.PlayOneShot(_playSaund, 0.5f);
            _audioSource.PlayOneShot(_playSaund2, 1f);
            Button.GetComponent<Collider2D>().enabled = false; 
            Invoke("spawnObj", time);
            anima2.SetBool("isOpen", false);
            IncreaseProgress();
        }
    }

    void spawnObj ()
    {
        _audioSource.PlayOneShot(_playSaund3, 1f);
        Move.muv = true;
        Box.SetActive(true);
    }
    public void IncreaseProgress()
    {
        targetFill = Mathf.Clamp01(fillImage.fillAmount + 0.1f);
    }
}