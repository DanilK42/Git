using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musor : MonoBehaviour
{
    public GameObject GameObject;

    private void Start()
    {
        GameObject.SetActive(true);
    }
    void Update()
    {
        if (ScoreManager.win == true)
        {
            GameObject.SetActive(false);
        }
    }
}