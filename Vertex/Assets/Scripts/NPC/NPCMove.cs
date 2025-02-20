using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public Transform[] waypoints;  // Массив точек маршрута
    public float speed = 2f;       // Скорость движения
    public float waitTime = 2f;    // Время ожидания на точке
    public Animator anima;         // Аниматор

    private int currentPoint = 0;
    private bool isWaiting = false; // Флаг ожидания на точке
    private bool isTalking = false; // Флаг разговора
    private bool playerInRange = false; // Игрок в радиусе действия?

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    public Collider2D detectionZone; // Коллайдер зоны для проверки (с Is Trigger)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.zero;
    }

    void Update()
    {
        if (waypoints.Length == 0 || isWaiting || isTalking) return;

        // Двигаемся к точке
        moveDirection = (waypoints[currentPoint].position - transform.position).normalized;

        // Если достигли точки - включаем паузу
        if (Vector2.Distance(transform.position, waypoints[currentPoint].position) < 0.1f)
        {
            StartCoroutine(WaitAtPoint());
        }

        UpdateAnimation();

        // Остановка при нажатии "E" (если игрок рядом)
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            isTalking = !isTalking; // Переключаем состояние разговора
            moveDirection = Vector2.zero; // Останавливаем NPC
            UpdateAnimation();
        }
    }

    void FixedUpdate()
    {
        if (!isWaiting && !isTalking)
        {
            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        }
    }

    private IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        moveDirection = Vector2.zero;
        UpdateAnimation();
        yield return new WaitForSeconds(Random.Range(5,8));
        currentPoint = (currentPoint + 1) % waypoints.Length;
        isWaiting = false;
    }

    private void UpdateAnimation()
    {
        anima.SetBool("IsUp", false);
        anima.SetBool("IsDown", false);
        anima.SetBool("IsRight", false);
        anima.SetBool("IsLeft", false);
        anima.SetBool("IsIdl", true);

        if (moveDirection.magnitude > 0.1f)
        {
            anima.SetBool("IsIdl", false);
            if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
            {
                if (moveDirection.x > 0) anima.SetBool("IsRight", true);
                else anima.SetBool("IsLeft", true);
            }
            else
            {
                if (moveDirection.y > 0) anima.SetBool("IsUp", true);
                else anima.SetBool("IsDown", true);
            }
        }
    }

    // Когда объект "DetectionZone" входит в зону
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Игрок рядом
            moveDirection = Vector2.zero; // Останавливаем NPC
            UpdateAnimation(); // Обновляем анимацию
        }
    }

    // Когда объект "DetectionZone" выходит из зоны
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Игрок вышел
            isTalking = false; // NPC продолжает движение
        }
    }
}