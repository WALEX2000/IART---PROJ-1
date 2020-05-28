using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InferenceManager : PuzzleManager
{
    public GameObject tilePrefab;
    public GameObject gameManager;
    public TileType[][] puzzleMatrix;
    private Puzzle puzzle;
    private List<Node> steps;

    //public Transform testTransform;
    public void Start() {
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0];
        steps = new List<Node>();
    }

    public override Puzzle generatePuzzle() {
        puzzle = new Puzzle(puzzleMatrix, tilePrefab).copy();
        puzzle.startPuzzle();
        puzzle.displayPuzzle();
        steps.Add(new Node(puzzle.copy(), null, 0));
        return puzzle;
    }

    public override void displayPuzzle(Puzzle puzzle, Transform puzzleTransform) {
        //Delete all children of the puzzleTransform
        foreach(Transform child in puzzleTransform) {
            Destroy(child.gameObject);
        }

        puzzle.displayPuzzle(puzzleTransform);
    }

    public override void addStep(Node step) {
        steps.Add(step);
    }

    public override void showResult() {
        Debug.Log("Got " + steps.Count + " steps");
        gameManager.GetComponent<GameManager>().AIrunning = true;
        StartCoroutine(gameManager.GetComponent<GameManager>().DisplayPuzzleStates(steps, 0.5f));
    }
}