using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    TimerCheck timer1;
    

    void Start()
    {
        timer1 = FindObjectOfType<TimerCheck>(); // ���� ������ � ���� ��������
        
        if (timer1 == null)
        {
            Debug.LogError("���� �� �������� �� ������! ���������, ���� �� ��� �� �����.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timer1 != null) timer1.CompleteLevel();

        }
    }
}
