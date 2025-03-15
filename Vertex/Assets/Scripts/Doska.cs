using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Doska : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    public GameObject DoskaCheck;
    public GameObject image;
    public Image button;
    public Animator BlackScren;
    public Animator DoskaAnim;
    public Animator e;
    private EnableButton enableButton;
    public Image Button;
    public Text text;

    private void Awake()
    {
        image.SetActive(true);
        button.gameObject.SetActive(false);
        enableButton = GetComponent<EnableButton>();
        text.gameObject.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Collider2D targetCollider = DoskaCheck.GetComponent<Collider2D>();
            targetCollider.enabled = false;
            Move.muv = false;
            BlackScren.SetTrigger("BlackWind");
            Invoke("IsOpen", 1.3f);
            e.SetBool("isOpen", false);
            

        }
    }

    void IsOpen()
    {
        DoskaAnim.SetBool("IsOpen", true);
        button.gameObject.SetActive(true);
        Button.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
    }
}
