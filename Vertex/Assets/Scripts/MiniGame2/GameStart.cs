using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Camera cam;
    public Transform scenCam;
    public Transform gameCam;
    public Animator anima;
    public float time;
    public GameObject checkGame;
    public GameObject LiftDor;
    private bool isPlayerInTrigger = false;
    [SerializeField] public Image textBar;


    private void Start()
    {
        LiftDor.SetActive(false);
        checkGame.SetActive(true);
        MoveP.Game = false;
        textBar.gameObject.SetActive(false);
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

    void Update()
    {
        if (BoxTeleport.Win == true)
        {
            LiftDor.SetActive(true);
            Move.muv = true;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport2", time);
            Debug.Log("Win");
            checkGame.SetActive(false);
            MoveP.Game = false;
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            MoveP.Game = true;
            Collider2D targetCollider = checkGame.GetComponent<Collider2D>();
            targetCollider.enabled = false;
            Move.muv = false;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport", time);
        }
    }

    void Teleport()
    {
        cam.transform.position = gameCam.position;
        textBar.gameObject.SetActive(true);
    }
    void Teleport2()
    {
        cam.transform.position = scenCam.position;
        textBar.gameObject.SetActive(false);
    }
}
