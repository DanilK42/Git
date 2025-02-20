using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public Transform[] waypoints;  // ������ ����� ��������
    public float speed = 2f;       // �������� ��������
    public float waitTime = 2f;    // ����� �������� �� �����
    public Animator anima;         // ��������

    private int currentPoint = 0;
    private bool isWaiting = false; // ���� �������� �� �����
    private bool isTalking = false; // ���� ���������
    private bool playerInRange = false; // ����� � ������� ��������?

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    public Collider2D detectionZone; // ��������� ���� ��� �������� (� Is Trigger)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.zero;
    }

    void Update()
    {
        if (waypoints.Length == 0 || isWaiting || isTalking) return;

        // ��������� � �����
        moveDirection = (waypoints[currentPoint].position - transform.position).normalized;

        // ���� �������� ����� - �������� �����
        if (Vector2.Distance(transform.position, waypoints[currentPoint].position) < 0.1f)
        {
            StartCoroutine(WaitAtPoint());
        }

        UpdateAnimation();

        // ��������� ��� ������� "E" (���� ����� �����)
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            isTalking = !isTalking; // ����������� ��������� ���������
            moveDirection = Vector2.zero; // ������������� NPC
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

    // ����� ������ "DetectionZone" ������ � ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // ����� �����
            moveDirection = Vector2.zero; // ������������� NPC
            UpdateAnimation(); // ��������� ��������
        }
    }

    // ����� ������ "DetectionZone" ������� �� ����
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // ����� �����
            isTalking = false; // NPC ���������� ��������
        }
    }
}