using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.MLAgents;
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
        if(steps == null) steps = new List<Node>();
    }

    public void startDecisions() {
        GameObject agent = GameObject.FindWithTag("Agent");
        agent.AddComponent(typeof(DecisionRequester));
    }

    public Puzzle getPuzzle() {
        return puzzle;
    }

    public override Puzzle generatePuzzle() {
        puzzle = new Puzzle(puzzleMatrix, tilePrefab).copy();
        puzzle.startPuzzle();
        puzzle.displayPuzzle();
        if(steps == null) {
            steps = new List<Node>();
        }
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

    public override void resetSteps() {
        steps.Clear();
    }

    public override void showResult() {
        Debug.Log("Got " + steps.Count + " steps");
        gameManager.GetComponent<GameManager>().AIrunning = true;
        StartCoroutine(gameManager.GetComponent<GameManager>().DisplayPuzzleStates(steps, 0.5f));
    }
}