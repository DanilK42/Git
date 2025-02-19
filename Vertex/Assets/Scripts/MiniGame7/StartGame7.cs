using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame7 : MonoBehaviour
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
    public GameObject Game;
    public Animator e;

    private void Awake()
    {
        LiftDor.SetActive(false);
        checkGame.SetActive(true);
        textBar.gameObject.SetActive(false);
        Game.SetActive(false);
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
        if (ScoreManager.win == true)
        {
            LiftDor.SetActive(true);
            Move.muv = true;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport2", time);
            Debug.Log("Win");
            checkGame.SetActive(false);
            Game.SetActive(false);

        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            MoveP.Game = true;
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
        textBar.gameObject.SetActive(true);
        cam.transform.position = gameCam.position;
        
    }
    void Teleport2()
    {
        textBar.gameObject.SetActive(false);
        cam.transform.position = scenCam.position;
        
    }
}
