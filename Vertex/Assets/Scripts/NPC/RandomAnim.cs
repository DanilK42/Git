using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : MonoBehaviour
{
    public Animator anim;
    private float timer;
    private float nextTimeToPlay;

    void Start()
    {
        nextTimeToPlay = Random.Range(3f, 20f); // Устанавливаем первый случайный интервал
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextTimeToPlay)
        {
            RandAnim();
            timer = 0;
            nextTimeToPlay = Random.Range(3f, 20f); // Устанавливаем новый случайный интервал
        }
    }

    void RandAnim()
    {
        anim.SetTrigger("IsTrigger"); // Запуск анимации
    }

}
