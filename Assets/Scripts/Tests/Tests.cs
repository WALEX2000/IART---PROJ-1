

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

    public void runTests(int times, string path)
    {
        Puzzle puzzleEasy = new Puzzle(Example.puzzleEasy1, tilePrefab);
        System.IO.File.WriteAllLines(path, runPuzzleTests(times, puzzleEasy));

        Puzzle puzzleEasy2 = new Puzzle(Example.puzzleEasy2, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleEasy2));

        // Puzzle puzzle4 = new Puzzle(Example.puzzle4, tilePrefab);
        // System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzle4));

        // Puzzle puzzleMedium = new Puzzle(Example.puzzleMedium, tilePrefab);
        // System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleMedium));

        // Puzzle puzzleIntermidiate = new Puzzle(Example.puzzleIntermidiate, tilePrefab);
        // System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleIntermidiate));

        // Puzzle puzzleDifficult = new Puzzle(Example.puzzleDifficult, tilePrefab);
        // System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleDifficult));

        // Puzzle puzzleHard = new Puzzle(Example.puzzleHard, tilePrefab);
        // System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleHard));

        // Puzzle puzzleExpert = new Puzzle(Example.puzzleExpert, tilePrefab);
        // System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleExpert));

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


