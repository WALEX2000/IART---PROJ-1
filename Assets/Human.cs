using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{

    private Vector3 mouseDownPos;
    private Vector3 lastMouseCoordinate = Vector3.zero;
    bool moving = false;

    public Puzzle puzzle;
    public TileType tile;

    private Vector3 v3Pos;
    private int threshold = 9;
    public MainMenu mainMenu;


    void OnMouseDown()
    {
        moving = true;
        v3Pos = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        if(!moving) return;

        puzzle.displayPuzzle();
        var v3 = Input.mousePosition - v3Pos;
        v3.Normalize();
        var f = Vector3.Dot(v3, Vector3.up);
        if (Vector3.Distance(v3Pos, Input.mousePosition) < threshold)
        {
            Debug.Log("No movement");
            return;
        }

        if (f >= 0.5)
        {
            Debug.Log("Up");
            puzzle.moveUp(tile);
        }
        else if (f <= -0.5)
        {
            Debug.Log("Down");
            puzzle.moveDown(tile);
        }
        else
        {
            f = Vector3.Dot(v3, Vector3.right);
            if (f >= 0.5)
            {
                Debug.Log("Right");
                puzzle.moveRight(tile);
            }
            else
            {
                Debug.Log("Left");
                puzzle.moveLeft(tile);
            }
        }

        puzzle.displayPuzzle();

        v3Pos = Input.mousePosition;

        if (puzzle.isComplete())
        {
            Debug.Log("Puzzle Completed successfuly");
        }

        moving = false;

    }

    void onMouseUp() {
        moving = false;
    }



    public void QuitGame()
    {
        Application.Quit();
    }

}
