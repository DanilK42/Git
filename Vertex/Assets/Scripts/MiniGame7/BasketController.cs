using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);


        float clampedX = Mathf.Clamp(transform.position.x, 118.50f, 133.40f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}