using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerType { Bot, Player };

public class GameManager : MonoBehaviour
{
    private Puzzle currentPuzzle;
    private playerType currentPlayer;
    public GameObject tilePrefab;


    public void Start()
    {
        Example example = new Example();
        currentPuzzle = new Puzzle(example.puzzle4, tilePrefab);

        var watch = System.Diagnostics.Stopwatch.StartNew();
        Node solution = currentPuzzle.search("IDDFSUndo");
        watch.Stop();

        Debug.Log("Time taken: " + watch.ElapsedMilliseconds / 1000.0);

        List<Puzzle> steps = solution.getPath();
        Debug.Log("Steps taken: " + steps.Count);

        StartCoroutine(DisplayPuzzleStates(steps, 2));
    }

    private List<Puzzle> puzzleStates = new List<Puzzle>();
    public void DisplayState(Puzzle puzzle)
    {
        puzzleStates.Add(puzzle);
    }

    private IEnumerator DisplayPuzzleStates(List<Puzzle> steps, int time)
    {
        //Debug.Log(puzzleStates.Count);
        for (int i = 0; i < steps.Count; i++)
        {
            if (i != 0)
                steps[i - 1].hidePuzzle();
            Puzzle puzzle = steps[i];
            puzzle.displayPuzzle();
            yield return new WaitForSeconds(time);
        }
    }
}
