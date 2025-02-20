using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpeanPincode : MonoBehaviour
{
    [SerializeField] private Image Consol;
    private bool isPlayerInTrigger = false;
    public Animator anima;
    public bool isOpean = true;
    public Animator e;

    void Awake()
    {
        if (Consol != null)
        {
            Consol.gameObject.SetActive(true);
        }
        isOpean = true;
    }

    private void Start()
    {
        if (Consol != null)
        {
            Consol.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            e.SetBool("isOpen", true);

            if (Consol != null)
            {
                Consol.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Consol != null)  // Проверяем, что объект существует
            {
                Consol.gameObject.SetActive(false);
            }

            isPlayerInTrigger = false;
            e.SetBool("isOpen", false);
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (isOpean)
            {
                anima.SetBool("IsOpean", true);
                isOpean = false;
                Move.muv = false;
            }
            else
            {
                anima.SetBool("IsOpean", false);
                isOpean = true;
                Move.muv = true;
            }
        }
    }
}
