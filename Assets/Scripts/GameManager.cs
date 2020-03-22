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

        currentPuzzle = new Puzzle(Puzzle.puzzle3, tilePrefab);
        currentPuzzle.displayPuzzle();

        Puzzle copy = currentPuzzle.copy();
        currentPuzzle.displayPuzzle();
        // copy.displayPuzzle();
        currentPuzzle.search("dfs");

          
    }
}
