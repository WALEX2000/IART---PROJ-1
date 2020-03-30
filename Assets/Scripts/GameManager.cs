using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerType { Bot, Player };

public class GameManager : MonoBehaviour
{
    private Puzzle currentPuzzle;
    private playerType currentPlayer;
    public GameObject tilePrefab;

    public GameObject hintButton;


    public void Start()
    {
        // Test test = new Test(tilePrefab);
        // test.runTests(5, "Assets/Scripts/Tests/results.txt");

        // currentPuzzle = new Puzzle(Example.puzzleEasy1, tilePrefab);

        // var watch = System.Diagnostics.Stopwatch.StartNew();
        // Node solution = currentPuzzle.search("DFSUndo");
        // currentPuzzle.displayPuzzle();


        // watch.Stop();

        // Debug.Log("Time taken: " + watch.ElapsedMilliseconds / 1000.0);

        // List<Puzzle> steps = solution.getPath();
        // Debug.Log("Steps taken: " + steps.Count);

        // StartCoroutine(DisplayPuzzleStates(steps, 2));

        /*
        currentPuzzle = new Puzzle(Example.puzzleHard, tilePrefab);

        var watch = System.Diagnostics.Stopwatch.StartNew();

        Node solution = currentPuzzle.search("UniqueFirstGreedy");

        Debug.Log("UniqueFirstGreedy");

        if(solution == null) {
            Debug.LogError("No solution found!");
            return;
        }

        watch.Stop();

        if(solution == null) {
            Debug.LogError("Algorithm failed to solve puzzle!!");
            return;
        }

        Debug.Log("Time taken: " + watch.ElapsedMilliseconds / 1000.0);
       
        List<Puzzle> steps = solution.getPath();

        Debug.Log("Steps taken: " + steps.Count);

        StartCoroutine(DisplayPuzzleStates(steps, 2));
        */

        //Puzzle puzzle = new Puzzle(Example.puzzleHard, tilePrefab);
        //puzzle.displayPuzzle();

    }

    public void ManagerStarter(string searchOption, TileType[][] puzzleLevel)
    {
        // Test test = new Test(tilePrefab);
        // test.runTests(5, "Assets/Scripts/Tests/results.txt");


        currentPuzzle = new Puzzle(puzzleLevel, tilePrefab);
        currentPuzzle.displayPuzzle();

        var watch = System.Diagnostics.Stopwatch.StartNew();

        Node solution = currentPuzzle.search(searchOption);

        /*if(solution == null) {
            Debug.Log("No solution");
            return;
        }*/

        Debug.Log(searchOption);

        watch.Stop();

        if (solution == null)
        {
            Debug.LogError("Algorithm failed to solve puzzle!!");
            return;
        }

        Debug.Log("Time taken: " + watch.ElapsedMilliseconds / 1000.0);

        List<Puzzle> steps = solution.getPath();

        Debug.Log("Steps taken: " + steps.Count);

        StartCoroutine(DisplayPuzzleStates(steps, 2));
    }

    public void HumanMode(TileType[][] puzzleLevel)
    {
        currentPuzzle = new Puzzle(puzzleLevel, tilePrefab);
        currentPuzzle.displayPuzzle();
        hintButton.GetComponent<GetHint>().puzzle = currentPuzzle;
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
