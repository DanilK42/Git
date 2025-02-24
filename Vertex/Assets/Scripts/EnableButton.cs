using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnableButton : MonoBehaviour
{
    public Image Image;
    public Animator BlackScren;
    public Animator DoskaAnim;
    public GameObject GameObject;
    private bool check;
    private bool isInAction = false;  // Флаг, чтобы предотвратить выполнение нескольких действий одновременно

    void Start()
    {
        Image.gameObject.SetActive(false);
        check = true;
        GameObject.SetActive(false);
    }

    public void Buttom()
    {
        if (isInAction) return;  // Если действие уже выполняется, выходим
        isInAction = true;

        if (check)
        {
            check = false;
            Move.muv2 = false;
            BlackScren.SetTrigger("BlackWind");
            Invoke("IsOpean", 1.3f);
        }
        else
        {
            check = true;
            BlackScren.SetTrigger("BlackWind");
            Invoke("IsClouse", 1.3f);
            GameObject.SetActive(false);
        }
    }

    public void IsOpean()
    {
        DoskaAnim.SetBool("IsOpen", true);
        GameObject.SetActive(true);
        isInAction = false;  // Сбрасываем флаг после завершения действия
    }

    public void IsClouse()
    {
        DoskaAnim.SetBool("IsOpen", false);
        Move.muv2 = true;
        isInAction = false;  // Сбрасываем флаг после завершения действия
    }

    public void Exit()
    {
        if (isInAction) return;  // Если действие уже выполняется, выходим
        isInAction = true;

        GameObject.SetActive(false);
        BlackScren.SetTrigger("BlackWind");
        Invoke("InExit", 1.3f);
    }

    public void InExit()
    {
        Application.Quit();
        Debug.Log("Игра закрыта");
        isInAction = false;  // Сбрасываем флаг после завершения действия
    }

    public void Menu()
    {
        if (isInAction) return;  // Если действие уже выполняется, выходим
        isInAction = true;

        GameObject.SetActive(false);
        BlackScren.SetTrigger("BlackWind");
        Invoke("InMenu", 1.3f);
    }

    public void InMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isInAction = false;  // Сбрасываем флаг после завершения действия
    }
}
