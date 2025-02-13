using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CodeManager : MonoBehaviour
{
    public Text textCode;
    public string code;
    public GameObject ElevatorChek;
    public GameObject PincodeChek;
    public Animator anima;

    private void Start()
    {
        ElevatorChek.SetActive(false);
    }

    void Update()
    {
        if (code == "")
        {
            textCode.text = "¬водите";
        }
        else
        {
            textCode.text = code;
        }
    }

    public void Button_1 ()
    {
        code += 1;
    }
    public void Button_2()
    {
        code += 2;
    }
    public void Button_3()
    {
        code += 3;
    }
    public void Button_4()
    {
        code += 4;
    }
    public void Button_5()
    {
        code += 5;
    }
    public void Button_6()
    {
        code += 6;
    }
    public void Button_7()
    {
        code += 7;
    }
    public void Button_8()
    {
        code += 8;
    }
    public void Button_9()
    {
        code += 9;
    }
    public void Button_0()
    {
        code += 0;
    }
    
    public void ButtonEnter()
    {
        if (code == "804")
        {
            ElevatorChek.SetActive(true);
            Move.muv = true;
            anima.SetBool("IsOpean", false);
            PincodeChek.SetActive (false);

        }
        else
        {
            Debug.Log("неверно бобик");
            
        }
        code = "";
    }
    public void ButtonDelete()
    {
        code = "";
    }

}
