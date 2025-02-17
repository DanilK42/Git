using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriger : MonoBehaviour
{
    public Animator anima;
    public Dialog dialog;
    private bool checkPosition = false;
    public bool check = false;
    public GameObject BoxCheck;

    private void Start()
    {
        BoxCheck.SetActive(false);
    }

    private void OpenDiag()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
        check = true;
        Move.muv = false;
    }
    private void ExitDiag()
    {
        FindObjectOfType<DialogManager>().ExitDialog(dialog);
        check = false;
        Move.muv = true;
    }
     


    private void Update()
    {
        if(checkPosition == true && Input.GetKeyDown(KeyCode.E) && check == false)
        {
            OpenDiag();
            BoxCheck.SetActive(true);
            anima.SetBool("isOpen", false);

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            checkPosition = true;
            anima.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            anima.SetBool("isOpen", false);
            checkPosition = false;
            ExitDiag();
            return;

        }
    }

}
