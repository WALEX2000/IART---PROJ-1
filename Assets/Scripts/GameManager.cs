using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerType { Bot, Player };

public class GameManager : MonoBehaviour
{
    private Puzzle currentPuzzle;
    private playerType currentPlayer;

    public GameObject tilePrefab;
    public void Start() {
        currentPuzzle = new Puzzle(Puzzle.puzzle1, tilePrefab);
        //currentPuzzle.displayPuzzle();
        currentPuzzle.displayConsole();
        TileType blue = TileType.Blue;
        currentPuzzle.moveUp(blue);
        currentPuzzle.displayPuzzle();
    }
}
