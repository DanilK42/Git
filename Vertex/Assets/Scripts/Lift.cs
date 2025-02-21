using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public Transform newPlayer;
    public Transform newCam;
    public Animator anima;
    public float time;
    [SerializeField] private AudioClip _playSaund3;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _audioSource.PlayOneShot(_playSaund3, 1f);
            Move.muv = false;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport", time);
            

        }
    }

    void Teleport ()
    {
        cam.transform.position = newCam.position;
        player.transform.position = newPlayer.position;
        Move.muv = true;
    }
}
