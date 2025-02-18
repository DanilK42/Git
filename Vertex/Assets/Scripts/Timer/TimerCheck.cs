using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCheck : MonoBehaviour
{
    [SerializeField] private float timePerLevel;  // Время на один уровень
    [SerializeField] private Text timerText;
    [SerializeField] private Text resultText;  // Текст для вывода результатов
    private float _timeLeft;
    private float _elapsedTime;  // Время, которое прошло на текущем уровне
    private bool _isRunning = false;  // Флаг работы таймера
    private List<float> levelTimes = new List<float>();  // Список для хранения времени каждого уровня
    private int currentLevel = 0;  // Номер текущего уровня
    private Coroutine _timerCoroutine;

    void Start()
    {
       

    }

    // Старт нового уровня
    public void StartLevel()
    {
        _timeLeft = timePerLevel;
        _elapsedTime = 0f;
        _isRunning = true;  // Таймер работает

        // Если корутина уже запущена, останавливаем её
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
        }

        // Запускаем новую корутину таймера
        _timerCoroutine = StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {

        // Запускаем таймер, если он еще не запущен
        _isRunning = true;

        while (_timeLeft > 0 && _isRunning)
        {
            _timeLeft += Time.deltaTime;  // Уменьшаем оставшееся время
            _elapsedTime += Time.deltaTime;  // Увеличиваем прошедшее время
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



    // Метод для завершения уровня
    public void CompleteLevel()
    {  if (currentLevel < 5 )
        {
            levelTimes.Add(_elapsedTime);  // Сохраняем время для текущего уровня
            Debug.Log($"Уровень {currentLevel + 1} завершен за {_elapsedTime:F2} секунд");
            
            StartLevel();
        }
        else 
        {
            ShowResults();
        }
        currentLevel++;

    }

    // Метод для вывода результатов
    private void ShowResults()
    {
        resultText.text = "Результаты:\n";
        for (int i = 0; i < levelTimes.Count; i++)
        {
            int minutes = Mathf.FloorToInt(levelTimes[i] / 60);
            int seconds = Mathf.FloorToInt(levelTimes[i] % 60);
            resultText.text += $"Уровень {i + 1}: {minutes:00}:{seconds:00}\n";
        }
        Debug.Log("Все уровни пройдены!");
    }
}
