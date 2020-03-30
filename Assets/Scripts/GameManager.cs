using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerType { Bot, Player };

public class GameManager : MonoBehaviour
{
    private Puzzle currentPuzzle;
    private Puzzle firstPuzzle;
    private playerType currentPlayer;
    public GameObject tilePrefab;

    public GameObject hintButton;


    public void Start()
    {
        // Test test = new Test(tilePrefab);
        // test.runTests(2, "Results/AStarwSize.txt");

    }

    public void ManagerStarter(string searchOption, TileType[][] puzzleLevel)
    {


        currentPuzzle = new Puzzle(puzzleLevel, tilePrefab);
        firstPuzzle = currentPuzzle.copy();
        currentPuzzle.displayPuzzle();

        var watch = System.Diagnostics.Stopwatch.StartNew();

        Node solution = currentPuzzle.search(searchOption);

        watch.Stop();
        Debug.Log(searchOption);
        Debug.Log("Time taken: " + watch.ElapsedMilliseconds / 1000.0);

        if (solution == null)
        {
            Debug.LogError("Algorithm failed to solve puzzle!!");
            return;
        }

        List<Puzzle> steps = solution.getPath();

        Debug.Log("Steps taken: " + steps.Count);

        StartCoroutine(DisplayPuzzleStates(steps, 1));
    }

    public void hidePuzzle()
    {
        currentPuzzle.hidePuzzle();
    }
    public void backToOriginal()
    {
        currentPuzzle = firstPuzzle;
    }

    public void HumanMode(TileType[][] puzzleLevel)
    {
        currentPuzzle = new Puzzle(puzzleLevel, tilePrefab);
        firstPuzzle = currentPuzzle.copy();
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
