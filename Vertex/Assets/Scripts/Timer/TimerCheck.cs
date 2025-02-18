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

    void Start()
    {
       

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
    {  if (currentLevel < 5 )
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
    private void ShowResults()
    {
        resultText.text = "����������:\n";
        for (int i = 0; i < levelTimes.Count; i++)
        {
            int minutes = Mathf.FloorToInt(levelTimes[i] / 60);
            int seconds = Mathf.FloorToInt(levelTimes[i] % 60);
            resultText.text += $"������� {i + 1}: {minutes:00}:{seconds:00}\n";
        }
        Debug.Log("��� ������ ��������!");
    }
}
