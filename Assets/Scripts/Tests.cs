

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.IO.File;

public class Test
{
    private GameObject tilePrefab;
    private List<string> operators;
    public Test(GameObject tilePrefab)
    {
        this.tilePrefab = tilePrefab;
        operators = new List<string>(new string[] { "BFS", "DFSUndo", "IDDFSUndo", "SimpleGreedy" });
    }

    public void runTests(int times)
    {
        Puzzle puzzleEasy = new Puzzle(Example.puzzleEasy1, tilePrefab);
        List<string> results = runPuzzleTests(times, puzzleEasy);
        System.IO.File.WriteAllLines("Assets/Scripts/results.txt", results);

        Puzzle puzzleEasy2 = new Puzzle(Example.puzzleEasy2, tilePrefab);
        results = runPuzzleTests(times, puzzleEasy2);
        System.IO.File.AppendAllLines("Assets/Scripts/results.txt", results);


        Puzzle puzzle4 = new Puzzle(Example.puzzle4, tilePrefab);
        results = runPuzzleTests(times, puzzle4);
        System.IO.File.AppendAllLines("Assets/Scripts/results.txt", results);


        Puzzle puzzleMedium = new Puzzle(Example.puzzleMedium, tilePrefab);
        results = runPuzzleTests(times, puzzleMedium);
        System.IO.File.AppendAllLines("Assets/Scripts/results.txt", results);

        Puzzle puzzleIntermidiate = new Puzzle(Example.puzzleIntermidiate, tilePrefab);
        results = runPuzzleTests(times, puzzleIntermidiate);
        System.IO.File.AppendAllLines("Assets/Scripts/results.txt", results);

        Puzzle puzzleDifficult = new Puzzle(Example.puzzleDifficult, tilePrefab);
        results = runPuzzleTests(times, puzzleDifficult);
        System.IO.File.AppendAllLines("Assets/Scripts/results.txt", results);

        Puzzle puzzleHard = new Puzzle(Example.puzzleHard, tilePrefab);
        results = runPuzzleTests(times, puzzleHard);
        System.IO.File.AppendAllLines("Assets/Scripts/results.txt", results);

        Puzzle puzzleExpert = new Puzzle(Example.puzzleExpert, tilePrefab);
        results = runPuzzleTests(times, puzzleExpert);
        System.IO.File.AppendAllLines("Assets/Scripts/results.txt", results);

    }
    public List<string> runPuzzleTests(int numberOfTimes, Puzzle puzzle)
    {
        List<string> final = new List<string>();
        foreach (string op in operators)
        {
            long time = 0;
            for (int i = 0; i < numberOfTimes; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Node solution = puzzle.search(op);
                watch.Stop();
                time += watch.ElapsedMilliseconds;
            }
            string s = op + ": " + ((time / 1000.0) / numberOfTimes);

            final.Add(s);
        }
        final.Add("\n");


        return final;

    }

}


