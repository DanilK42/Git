using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcStart : MonoBehaviour
{

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj1_1;
    public GameObject obj2_1;
    public GameObject obj3_1;
    private bool checkPosition = false;

    void Awake()
    {
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        obj1_1.SetActive(true);
        obj2_1.SetActive(true);
        obj3_1.SetActive(true);
    }

   

    private void Update()
    {
        if (checkPosition == true && Input.GetKeyDown(KeyCode.E))
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
            obj3.SetActive(true);
            obj1_1.SetActive(false);
            obj2_1.SetActive(false);
            obj3_1.SetActive(false);
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
