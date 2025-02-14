using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    Transform parentNode;
    Vector3 destinationPoint;
    bool inited;

    public void Init(Transform tr)
    {
        parentNode = tr;
        destinationPoint = tr.position;
        Debug.Log("Изменение цвета на объекте: " + gameObject.name);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = new Color(0.0f, 1.0f, 0.0f);
        }
        else
        {
            Debug.LogWarning("SpriteRenderer не найден на " + gameObject.name);
        }

        inited = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inited && parentNode != null) // Проверяем, существует ли родитель
        {
            transform.position = transform.position + (destinationPoint - transform.position) * 5f * Time.fixedDeltaTime;
            if ((transform.position - destinationPoint).sqrMagnitude < 0.1f)
            {
                destinationPoint = parentNode.position;
            }
        }
    }

}
