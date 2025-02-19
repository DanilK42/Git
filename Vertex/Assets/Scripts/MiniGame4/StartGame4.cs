using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame4 : MonoBehaviour
{
    public Camera cam;
    public Transform scenCam;
    public Transform gameCam;
    public Animator anima;
    public float time;
    public GameObject checkGame;
    public GameObject dialog;
    private bool isPlayerInTrigger = false;
    public bool clouseGame ;
    public Animator e;

    private void Awake()
    {
        checkGame.SetActive(true);
        clouseGame = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            e.SetBool("isOpen", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            e.SetBool("isOpen", false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && clouseGame == true)
        {
            Move.muv = true;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport2", time);
            clouseGame = false;
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && clouseGame == false)
        {
            Collider2D targetCollider = checkGame.GetComponent<Collider2D>();
            targetCollider.enabled = false;
            Move.muv = false;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport", time);
            clouseGame = true;
        }
    }

    void Teleport()
    {
        cam.transform.position = gameCam.position;
        e.SetBool("isOpen", true);
    }
    void Teleport2()
    {
        cam.transform.position = scenCam.position;
        checkGame.GetComponent<Collider2D>().enabled = true; // ¬ключаем коллайдер обратн
    }
}
