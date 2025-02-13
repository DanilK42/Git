using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpeanPincode : MonoBehaviour
{
    [SerializeField] public Image Consol;
    private bool isPlayerInTrigger = false;
    public Animator anima;
    public bool isOpean = true;
    void Start()
    {
        Consol.gameObject.SetActive(true);
        isOpean = true;
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
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && isOpean == true)
        {
            anima.SetBool("IsOpean",true);
            isOpean =false;
            Move.muv = false;
        }
        else if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && isOpean == false)
        {
            anima.SetBool("IsOpean", false);
            isOpean = true;
            Move.muv = true;
        }
        
    }
}
