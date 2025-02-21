using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] private AudioClip _playSaund1;
    private AudioSource _audioSource;
    private bool isPlayerInTrigger;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            _audioSource.PlayOneShot(_playSaund1, 1f);

        }
    }
    public void PlaySaund ()
    {
        _audioSource.PlayOneShot(_playSaund1, 0.5f);
    }
}
