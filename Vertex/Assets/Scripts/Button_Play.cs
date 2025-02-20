using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;
using UnityEngine.UI;
public class Button_Play : MonoBehaviour
{
    private bool isPlayerInTrigger;
    public Camera cam;
    public Transform gameCam;
    public Transform GamePlayer;
    public GameObject player;
    public Animator anima;
    private SpriteRenderer spriteRenderer;
    public Image Button;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент
        
    }

    public void SetTransparency(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp01(alpha); // Ограничиваем от 0 до 1
        spriteRenderer.color = color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            SetTransparency(1f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            SetTransparency(0.5f);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            
            
            Move.muv = false;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport", 1.4f);
            
        }
    }

    void Teleport()
    {
        cam.transform.position = gameCam.position;
        player.transform.position = GamePlayer.position;
        Move.muv = true;
        Button.gameObject.SetActive(true);
    }
}
