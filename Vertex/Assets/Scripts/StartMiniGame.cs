using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class StartMiniGame : MonoBehaviour
{
    public Camera cam;
    public Transform scenCam;
    public Transform gameCam;
    public Animator anima;
    public Animator e;
    public float time;
    public GameObject checkGame;
    public GameObject LiftDor;
    private bool isPlayerInTrigger = false;


    private void Awake()
    {
        LiftDor.SetActive(false);
        checkGame.SetActive(true);
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
            e.SetBool("isOpen", false);
            isPlayerInTrigger = false;
        }
    }

    void Update()
    {
        if (PuzzleManager.Win == true)
        {
            LiftDor.SetActive(true);
            Move.muv = true;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport2", time);
            Debug.Log("Win");
            checkGame.SetActive(false);
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            e.SetBool("isOpen", true);
            Collider2D targetCollider = checkGame.GetComponent<Collider2D>();
            targetCollider.enabled = false;
            Move.muv = false;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport", time);
            e.SetBool("isOpen", false);
        }
    }

    void Teleport()
    {
        cam.transform.position = gameCam.position;
    }
    void Teleport2()
    {
        cam.transform.position = scenCam.position;
    }
}
