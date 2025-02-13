using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class BoxTeleport : MonoBehaviour
{
    public static bool Win;
    void Start()
    {
        Win = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Win = true;

        }

        
    }
}
