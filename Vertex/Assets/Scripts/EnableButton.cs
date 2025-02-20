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
    void Start()
    {
        Image.gameObject.SetActive(false);
        check = true;
        GameObject.SetActive(false);
    }

    public void Buttom()
    {
        if (check)
        {
            check = false;
            Move.muv = false;
            BlackScren.SetTrigger("BlackWind");
            Invoke("IsOpean", 1.3f);
        }
        else if (check == false)
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
    }
    public void IsClouse()
    {
        DoskaAnim.SetBool("IsOpen", false);
        
        Move.muv = true;
    }

    public void Exit()
    {
        GameObject.SetActive(false);
        BlackScren.SetTrigger("BlackWind");
        Invoke("InExit", 1.3f);
    }

    public void InExit()
    {
        Application.Quit();
        Debug.Log("Игра закрыта");
    }
    public void Menu()
    {
        GameObject.SetActive(false);
        BlackScren.SetTrigger("BlackWind");
        Invoke("InMenu", 1.3f);
    }

    public void InMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
