using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MoveHead : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed = 1.0f;
    public GameObject parentObject;
    [SerializeField]
    GameObject foodPrefab;
    public Transform StartPos;
    Transform lastNode;
    public int chet = 0;
    [SerializeField] private Text scoreText;
    public static bool Win = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        lastNode = transform;
        scoreText.text = chet + " из 20";
    }

    // Update is called once per frame
    void Update()
    {

        if (chet == 20)
        {
            scoreText.gameObject.SetActive(false);
            Win = true;
            Debug.Log("Победа братуха42");
        }
        if (Input.GetAxis("Horizontal") != 0f)
        {
            transform.Rotate(0f, 0f, -180f * Time.deltaTime * Input.GetAxis("Horizontal"));
            rb.velocity = transform.up * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Food"))
        {
            if (lastNode == transform)
            {
                col.gameObject.tag = "Tale"; // Первый сегмент становится хвостом сразу
            }
            else
            {
                StartCoroutine(SetTagWithDelay(col.transform)); // Добавляем задержку
            }

            col.transform.GetComponent<Node>().Init(lastNode);
            lastNode = col.transform;
            GenerateFood();
            chet++;
            scoreText.text = chet + " из 20";
        }

        // Проверяем столкновение с границей или сегментом хвоста (но не с новым, у которого задержка)
        if (col.gameObject.CompareTag("Border") || (col.gameObject.CompareTag("Tale") && col.transform != lastNode))
        {
            Debug.Log("Crashed on " + col.gameObject.tag);
            ResetGame();
        }
    }

    IEnumerator SetTagWithDelay(Transform tr)
    {
        yield return new WaitForSeconds(0.5f);

        // Проверяем, не был ли объект удалён
        if (tr != null && tr.gameObject != null)
        {
            tr.gameObject.tag = "Tale";
        }
    }


    void GenerateFood()
    {
        // Создаём случайную позицию для нового объекта
        Vector3 randomPosition = new Vector3(Random.Range(101f, 114f), Random.Range(-6f, -13f), 0f);

        // Инстанцируем объект
        GameObject food = Instantiate(foodPrefab, randomPosition, Quaternion.identity);

        // Устанавливаем родительский объект (например, это может быть объект, к которому прикреплён этот скрипт)
        food.transform.SetParent(parentObject.transform);
    }
    void ResetGame()
    {
        chet = 0;
        scoreText.text = chet + " из 20";
        // Остановка движения змейки
        rb.velocity = Vector2.zero;

        // Сбрасываем позицию головы змейки
        transform.position = StartPos.position;
        transform.rotation = Quaternion.identity;

        // Удаляем все сегменты хвоста
        foreach (Transform child in transform.parent)
        {
            if (child.CompareTag("Tale"))
            {
                Destroy(child.gameObject);
            }
        }

        // Сбрасываем переменные
        lastNode = transform;

        // Перезапускаем движение
        rb.velocity = transform.up * speed;
    }
}
