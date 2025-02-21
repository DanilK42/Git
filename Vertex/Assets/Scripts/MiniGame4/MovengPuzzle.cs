using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovengPuzzle : MonoBehaviour
{
    public Play play;
    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            play.PlaySaund();
            move = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Конвертация координат
            startPosX = mousePos.x - transform.position.x;
            startPosY = mousePos.y - transform.position.y;
        }
    }

    private void OnMouseUp()
    {
        move = false;
    }

    private void Update()
    {
        if (move)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Конвертация координат
            transform.position = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }

}
