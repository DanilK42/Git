using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private GameObject[] puzzle;
    
    private static bool win;

    public static bool Win
    {
        get { return win; }
        set
        {
            win = value;
            if (win) Debug.Log("Win is now TRUE");
        }
    }

    private void Start()
    {
        puzzle = GameObject.FindGameObjectsWithTag("Puzzle");
        
        Win = false;
    }

    public void Update()
    {
        bool allTrue = true;
        foreach (var item in puzzle)
        {
            if (item.transform.rotation.z < -0.01 || item.transform.rotation.z > 0.01)
            {
                allTrue = false;
                break;
            }
        }

        if (allTrue && !Win) // Проверяем, что Win ещё не установлен
        {
            
            Debug.Log("YOU WIN");
            Win = true;
        }
    }
}
