using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Image[] flasks;
    public Button[] buttons;
    public Text[] flaskTexts;
    public Button resetButton;

    private int[] flaskLevels;
    private int maxFlaskLevel = 100;
    public static bool win = false;

    void Start()
    {
        flaskLevels = new int[3] { 0, 0, 0 };
        UpdateFlaskUI();

        // Привязка кнопок к методам
        buttons[0].onClick.AddListener(FillFirstFlask);
        buttons[1].onClick.AddListener(MoveFromFirstToThird);
        buttons[2].onClick.AddListener(MoveFromThirdToSecond);
        resetButton.onClick.AddListener(ResetFlasks);
    }

    void FillFirstFlask()
    {
        if (flaskLevels[0] < maxFlaskLevel)
        {
            flaskLevels[0] += 10;
            UpdateFlaskUI();
            CheckVictoryCondition();
        }
    }

    void MoveFromFirstToThird()
    {
        if (flaskLevels[0] > 0 && flaskLevels[2] < maxFlaskLevel)
        {
            int transferAmount = Mathf.Min(10, flaskLevels[0]);
            flaskLevels[0] -= transferAmount;
            flaskLevels[2] += transferAmount;
            UpdateFlaskUI();
            CheckVictoryCondition();
        }
    }

    void MoveFromThirdToSecond()
    {
        if (flaskLevels[2] > 0 && flaskLevels[1] < maxFlaskLevel)
        {
            int transferAmount = Mathf.Min(10, flaskLevels[2]);
            flaskLevels[2] -= transferAmount;
            flaskLevels[1] += transferAmount;
            UpdateFlaskUI();
            CheckVictoryCondition();
        }
    }

    void ResetFlasks()
    {
        flaskLevels = new int[3] { 0, 0, 0 };
        UpdateFlaskUI();
    }

    void CheckVictoryCondition()
    {
        if (flaskLevels[0] == 30 && flaskLevels[1] == 100 && flaskLevels[2] == 50)
        {
            Debug.Log("Победа! Уровни заполнения колб соответствуют условиям.");
            win = true;
        }

    }

    void UpdateFlaskUI()
    {
        for (int i = 0; i < flasks.Length; i++)
        {
            flasks[i].fillAmount = (float)flaskLevels[i] / maxFlaskLevel;
            flaskTexts[i].text = flaskLevels[i] + "/" + maxFlaskLevel;
        }
    }
}
