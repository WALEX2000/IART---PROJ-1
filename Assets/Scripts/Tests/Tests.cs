

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
        //operators = new List<string>(new string[] { "BFS", "IDDFSUndo", "DFS", "DFSUndo", "SimpleGreedy", "UniqueFirstGreedy", "UniformCost", "AStar" });
        //operators = new List<string>(new string[] { "IDDFSUndo", "DFS", "DFSUndo", "SimpleGreedy", "UniqueFirstGreedy", "UniformCost", "AStar" });
        operators = new List<string>(new string[] { "DFS", "DFSUndo", "SimpleGreedy", "UniqueFirstGreedy", "UniformCost", "AStar" });
        //operators = new List<string>(new string[] { "UniqueFirstGreedy", "UniformCost", "AStar" });
        //operators = new List<string>(new string[] { "UniformCost", "AStar" });
    }

    public void runTests(int times, string path)
    {
        /*
        Debug.Log("Level 1");
        Puzzle puzzleEasy = new Puzzle(Example.puzzleEasy1, tilePrefab);
        System.IO.File.WriteAllLines(path, runPuzzleTests(times, puzzleEasy));

        Debug.Log("Level 2");
        Puzzle puzzle4 = new Puzzle(Example.puzzle4, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzle4));

        Debug.Log("Level 3");
        Puzzle puzzleMedium = new Puzzle(Example.puzzleMedium, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleMedium));
        */

        Debug.Log("Level 4");
        Puzzle puzzle2275 = new Puzzle(Example.puzzle2275, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzle2275));

        /*
        Debug.Log("Level 5");
        Puzzle puzzleDifficult = new Puzzle(Example.puzzleDifficult, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleDifficult));

        Debug.Log("Level 6");
        Puzzle puzzleHard = new Puzzle(Example.puzzleHard, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleHard));

        Debug.Log("Level 7");
        Puzzle puzzle761 = new Puzzle(Example.puzzle761, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzle761));

        Debug.Log("Level 8");
        Puzzle puzzle2251 = new Puzzle(Example.puzzle2251, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzle2251));

        Debug.Log("Level 9");
        Puzzle puzzleExpert = new Puzzle(Example.puzzleExpert, tilePrefab);
        System.IO.File.AppendAllLines(path, runPuzzleTests(times, puzzleExpert));
        */

        Debug.Log("Finished Tests");

    }
    public List<string> runPuzzleTests(int numberOfTimes, Puzzle puzzle)
    {
        List<string> final = new List<string>();
        foreach (string op in operators)
        {
            Debug.Log(op);
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


