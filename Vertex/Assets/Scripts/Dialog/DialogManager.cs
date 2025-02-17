using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public Image headText;

    public Queue<string> Setences;
    public Queue<string> Name;
    public Queue<Sprite> Head;

    public Animator anim;


    private void Start()
    {
        Setences = new Queue<string>();
        Name = new Queue<string>();
        Head = new Queue<Sprite>();
    }

    public void StartDialog(Dialog dialog)
    {
        anim.SetBool("IsOpen", true);
        Setences.Clear();
        Name.Clear();
        Head.Clear();

        foreach (Sprite head in dialog.head)
        {
            Head.Enqueue(head);

        }
        foreach (string name in dialog.name)
        {
            Name.Enqueue(name);
        }
        foreach (string setences in dialog.setences)
        {
            Setences.Enqueue(setences);
        }
        DisplayNextSetences();
    }

    public void DisplayNextSetences()
    {
        if (Setences.Count == 0)
        {
            EndDialog();
            return;
        }
        StopAllCoroutines();
        string setence = Setences.Dequeue();
        string name = Name.Dequeue();
        Sprite head = Head.Dequeue();
        StartCoroutine(TypeSetences(setence, name, head));

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSetences();
        }
    }

    IEnumerator TypeSetences(string setence, string name, Sprite head)
    {
        dialogText.text = "";
        nameText.text = name;
        headText.sprite = head;

        foreach (char letter in setence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }

    }

    public void ExitDialog(Dialog dialog)
    {
        anim.SetBool("IsOpen", false);
        Move.muv = true;

    }



    public void EndDialog()
    {
        anim.SetBool("IsOpen", false);
        Move.muv = true;
    }


}
