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
        //Test test = new Test(tilePrefab);
        //test.runTests(5, "Assets/Scripts/Tests/results.txt");

        // var watch = System.Diagnostics.Stopwatch.StartNew();
        // Node solution = currentPuzzle.search("BFS");
        // watch.Stop();


        watch.Stop();

        // StartCoroutine(DisplayPuzzleStates(steps, 2));

        currentPuzzle = new Puzzle(Example.puzzleMedium, tilePrefab);

        currentPuzzle.displayPuzzle();

        UniqueFirstGreedy greedy = new UniqueFirstGreedy();
        List<Puzzle> solution = greedy.solve(currentPuzzle);

        StartCoroutine(DisplayPuzzleStates(solution, 2));
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
