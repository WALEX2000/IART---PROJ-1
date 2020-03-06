using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerType { Bot, Player };

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Puzzle puzzle = new Puzzle(3);
    }
}
