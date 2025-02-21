using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int winScore = 20;
    public int maxMissedApples = 3;
    public Text scoreText;
    public Image image;
    private int missedApples = 0;
    public static bool win = false;
    

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();


        if (score >= winScore)
        {
            WinGame();
        }
    }

    public void MissApple()
    {
        missedApples++;
        Debug.Log("Яблоко пропущено! Пропущенные: " + missedApples);


        if (missedApples >= maxMissedApples)
        {
            LoseGame();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Счет: " + score + " из 20";
    }

    void WinGame()
    {
        Debug.Log("Вы победили!");
        win = true;
        scoreText.gameObject.SetActive(false);
        image.gameObject.SetActive(false);

    }

    void LoseGame()
    {
        Debug.Log("Вы проиграли!");
        score = 0;
        missedApples = 0;
        scoreText.text = "Счет: " + score + " из 20";

    }
}
