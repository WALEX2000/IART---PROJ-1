using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//Objective: Do the more unique solutions first
//How
//For a puzzle, expand all colors in four directions
//See what are the moves that result in more unique solutions
//Do those first
public class SimpleGreedy
{


    private List<TileType> colors;
    private Puzzle current;

    private PriorityQueue<Puzzle> priorityQueue;

    public SimpleGreedy(Puzzle puzzle)
    {
        colors = puzzle.puzzleColors();
        this.current = puzzle;
        priorityQueue = new PriorityQueue<Puzzle>();

    }



    //Preenche primeiro os maiores
    public static int calculatePuzzleScore(Puzzle current)
    {

        int score = 0;
        for (int i = 0; i < current.PuzzleMatrix.Length; i++)
        {
            for (int j = 0; j < current.PuzzleMatrix[0].Length; j++)
            {
                if (current.PuzzleMatrix[i][j] != TileType.Null && current.PuzzleMatrix[i][j] != TileType.Empty) score += 1;
            }
        }
        return score;
    }


    public bool search()
    {
        priorityQueue.Enqueue(current);
        while (priorityQueue.Count() != 0)
        {
            if (greedySearch())
            {
                return true;
            }
        }
        return false;
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

        current.displayConsole();

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

