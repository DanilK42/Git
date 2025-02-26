using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    public float rotationAngle = 90f;
    public Play play;

    private void Start()
    {
        int[] rotate = { 0, 90, 180, 270 };
        transform.Rotate(0,0,rotate[Random.Range(0, rotate.Length)]);
        
    }

    void OnMouseDown()
    {
        play.PlaySaund();
        transform.Rotate(0, 0, rotationAngle);
    }
}
