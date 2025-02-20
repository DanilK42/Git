using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExclamation : MonoBehaviour
{
    public GameObject destroy;
    private bool checkPosition = false;

    private void Update()
    {
        if (checkPosition == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(destroy);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            checkPosition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            checkPosition = false;

        }
    }
}