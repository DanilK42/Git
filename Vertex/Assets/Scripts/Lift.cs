using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public Transform newPlayer;
    public Transform newCam;
    public Animator anima;
    public float time;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Move.muv = false;
            anima.SetTrigger("BlackWind");
            Invoke("Teleport", time);
            

        }
    }

    void Teleport ()
    {
        cam.transform.position = newCam.position;
        player.transform.position = newPlayer.position;
        Move.muv = true;
    }
}
