using UnityEngine;

public class StartTime : MonoBehaviour
{
    TimerCheck timer1;
    Timer timer2;

    void Start()
    {
        timer1 = FindObjectOfType<TimerCheck>(); // Ищет объект с этим скриптом
        timer2 = FindObjectOfType<Timer>();      // Ищет объект с этим скриптом

        if (timer1 == null || timer2 == null)
        {
            Debug.LogError("Один из таймеров не найден! Проверьте, есть ли они на сцене.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timer1 != null) timer1.StartLevel();
            if (timer2 != null) timer2.StartLevel();
            Destroy(gameObject);
        }
    }
}