using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;
    [SerializeField] private Text Text;
    private float _timeLeft;
    TimerCheck timer1;
    private void Start()
    {
        timer1 = FindObjectOfType<TimerCheck>();
    }
    public void StartLevel()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while(_timeLeft > 0)
        {
            _timeLeft+= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
        _timeLeft = 0;
        UpdateTimeText();
        timer1.ShowResults();
        
    }
    public void StopTimer()
    {
        StopAllCoroutines();
        Debug.Log("Таймер остановлен");
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0) 
             _timeLeft= 0;

        float minutes = Mathf.FloorToInt(_timeLeft/60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
