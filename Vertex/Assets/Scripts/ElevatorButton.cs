using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public GameObject Box;
    public GameObject Button;
    public Animator anima;
    public float time;
    private bool isPlayerInTrigger = false;

    private void Start()
    {
        Box.SetActive(false);
        Button.SetActive(true);
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

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Button.SetActive(false);
            Move.muv = false;
            anima.SetTrigger("ElevatorButton");
            Invoke("spawnObj", time);
        }
    }

    void spawnObj ()
    {
        
        Move.muv = true;
        Box.SetActive(true);
    }
}