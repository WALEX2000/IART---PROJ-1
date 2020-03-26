using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//Objective: Do the more unique solutions first
//How
//For a puzzle, expand all colors in four directions
//See what are the moves that result in more unique solutions
//Do those first
public class Greedy
{


    private List<TileType> colors;
    private Puzzle current;

    private Queue<Puzzle> priorityQueue;
    private HashSet<Puzzle> visited;


    public bool search(Puzzle puzzle)
    {
        colors = puzzle.puzzleColors();
        this.current = puzzle;
        priorityQueue = new Queue<Puzzle>();
        PriorityQueue<Puzzle> pq = new PriorityQueue<Puzzle>();
        visited = new HashSet<Puzzle>();

        priorityQueue.Enqueue(current);
        while (priorityQueue.Count != 0)
        {
            if (greedySearch()) return true;
        }
        return false;
    }


    //Versão ainda muito rudimentar de como calcular
    //Ver os filhos e calcular matriz de score de todas somadas
    public int calculateMatrixScore(Puzzle puzzle)
    {

        List<List<int>> matrix = new List<List<int>>();



        foreach (TileType tile in colors)
        {

            Puzzle puzzleDown = current.copy();
            if (puzzleDown.moveDown(tile))
            {

            }
            Puzzle puzzleUp = current.copy();

            if (puzzleUp.moveUp(tile))
            {
            }
            Puzzle puzzleLeft = current.copy();
            if (puzzleLeft.moveLeft(tile))
            {
            }
            Puzzle puzzleRight = current.copy();
            if (puzzleRight.moveRight(tile))
            {

            }

        }
        return 0;

    }



    //Given a puzzle calculates its matrix
    public List<List<int>> calculateMatrix(Puzzle puzzle)
    {

        List<List<int>> scoreMatrix = new List<List<int>>();

        for (int i = 0; i < puzzle.PuzzleMatrix.Length; i++)
        {
            List<int> scoreLine = new List<int>();
            for (int j = 0; j < puzzle.PuzzleMatrix[0].Length; j++)
            {
                if (puzzle.PuzzleMatrix[i][j] == TileType.Null) scoreLine.Add(0);  //Give Null Elements 0 Points
                else if (puzzle.PuzzleMatrix[i][j] == TileType.Empty) scoreLine.Add(9); //Give Empty Elements 9 pointss
                else scoreLine.Add(1); //Give 1 Point to each color
            }
            scoreMatrix.Add(scoreLine);
        }

        return scoreMatrix;
    }



    //Tambem pode servir como heuristica para quao mais preenchido melhor
    public static int calculatePuzzleScore(Puzzle current)
    {

        int score = 0;
        for (int i = 0; i < current.PuzzleMatrix.Length; i++)
        {
            for (int j = 0; j < current.PuzzleMatrix[0].Length; j++)
            {
                if (current.PuzzleMatrix[i][j] == TileType.Null) continue;  //Give Null Elements 0 Points
                else if (current.PuzzleMatrix[i][j] == TileType.Empty) score += 9; //Give Empty Elements 9 pointss
                else score += 1; //Give 1 Point to each color
            }
        }

        return score;
    }




    //Nao esquecer que o BFS funcionava melhor com uma lista do que com uma queue
    public bool greedySearch()
    {


        Puzzle current = priorityQueue.Dequeue();

        if (current.isComplete())
        {
            current.displayPuzzle();
            return true;
        }
        if (visited.Contains(current)) return false;
        visited.Add(current);


        foreach (TileType tile in colors)
        {
            Puzzle puzzleDown = current.copy();
            if (puzzleDown.moveDown(tile))
            {
                priorityQueue.Enqueue(puzzleDown);
            }
            Puzzle puzzleUp = current.copy();

            if (puzzleUp.moveUp(tile))
            {
                priorityQueue.Enqueue(puzzleUp);
            }
            Puzzle puzzleLeft = current.copy();
            if (puzzleLeft.moveLeft(tile))
            {
                priorityQueue.Enqueue(puzzleLeft);
            }
            Puzzle puzzleRight = current.copy();
            if (puzzleRight.moveRight(tile))
            {
                priorityQueue.Enqueue(puzzleRight);
            }
        }

        return false;

    }




}


