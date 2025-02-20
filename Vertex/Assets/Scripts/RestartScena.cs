using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RestartScena : MonoBehaviour
{
    public Animator anima;
    public Animator anima1;

    private void Awake()
    {
        anima1.SetTrigger("IsWind");
    }

    public void Buttom ()
    {
        anima.SetTrigger("BlackWind");
        Invoke("RestartScene", 1.4f);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
