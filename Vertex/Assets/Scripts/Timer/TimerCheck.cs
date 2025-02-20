using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCheck : MonoBehaviour
{
    [SerializeField] private float timePerLevel;  // ����� �� ���� �������
    [SerializeField] private Text timerText;
    [SerializeField] private Text resultText;  // ����� ��� ������ �����������
    private float _timeLeft;
    private float _elapsedTime;  // �����, ������� ������ �� ������� ������
    private bool _isRunning = false;  // ���� ������ �������
    private List<float> levelTimes = new List<float>();  // ������ ��� �������� ������� ������� ������
    private int currentLevel = 0;  // ����� �������� ������
    private Coroutine _timerCoroutine;
    Timer timer1;
    void Start()
    {
        timer1 = FindObjectOfType<Timer>();

    }

    // ����� ������ ������
    public void StartLevel()
    {
        _timeLeft = timePerLevel;
        _elapsedTime = 0f;
        _isRunning = true;  // ������ ��������

        // ���� �������� ��� ��������, ������������� �
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
        }

        // ��������� ����� �������� �������
        _timerCoroutine = StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {

        // ��������� ������, ���� �� ��� �� �������
        _isRunning = true;

        while (_timeLeft > 0 && _isRunning)
        {
            _timeLeft += Time.deltaTime;  // ��������� ���������� �����
            _elapsedTime += Time.deltaTime;  // ����������� ��������� �����
            UpdateTimeText();
            yield return null;
        }

        if (_timeLeft <= 0 && _isRunning)
        {
            _timeLeft = 0;
            UpdateTimeText();
            
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }



    // ����� ��� ���������� ������
    public void CompleteLevel()
    {  if (currentLevel < 9 )
        {
            levelTimes.Add(_elapsedTime);  // ��������� ����� ��� �������� ������
            Debug.Log($"������� {currentLevel + 1} �������� �� {_elapsedTime:F2} ������");
            
            StartLevel();
        }
        else 
        {
            ShowResults();
        }
        currentLevel++;

    }

    // ����� ��� ������ �����������
    public void ShowResults()
    {
        StopTimer();
        resultText.text = "����������:\n";

        float totalElapsedTime = 0f; // ����� ����� ����������� ���� �������

        for (int i = 0; i < levelTimes.Count; i++)
        {
            int minutes = Mathf.FloorToInt(levelTimes[i] / 60);
            int seconds = Mathf.FloorToInt(levelTimes[i] % 60);
            resultText.text += $"������� {i + 1}....................................................{minutes:00}:{seconds:00}\n";

            totalElapsedTime += levelTimes[i]; // ��������� ����� �����
        }

        // ����� ������ �������
        int totalMinutes = Mathf.FloorToInt(totalElapsedTime / 60);
        int totalSeconds = Mathf.FloorToInt(totalElapsedTime % 60);
        resultText.text += $"����� ����� � ����: {totalMinutes:00}:{totalSeconds:00}\n";

        timer1.StopTimer();
        Debug.Log("��� ������ ��������!");

    }
    public void StopTimer()
    {
        StopAllCoroutines(); // ������������� ��� ��������, ������� ����� � ������� �������
        _isRunning = false;  // ������������� ������ ������
        Debug.Log("������ ����������");
    }
}
