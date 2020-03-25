
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BFS
{
    private Queue<Puzzle> searchQueue;

    private List<TileType> colors;
    private Puzzle puzzle;


    public BFS(Puzzle puzzle)
    {
        colors = puzzle.puzzleColors();
        this.puzzle = puzzle.copy();
    }

    public bool search()
    {
        searchQueue = new Queue<Puzzle>();
        searchQueue.Enqueue(puzzle);
        while (searchQueue.Count != 0)
        {
            if (breadthFirstSearch())
            {
                return true;
            }
        }
        return false;
    }

    public bool breadthFirstSearch()
    {


        Puzzle current = searchQueue.Dequeue();

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
                searchQueue.Enqueue(puzzleDown);
            }
            Puzzle puzzleUp = current.copy();

            if (puzzleUp.moveUp(tile))
            {
                searchQueue.Enqueue(puzzleUp);
            }
            Puzzle puzzleLeft = current.copy();
            if (puzzleLeft.moveLeft(tile))
            {
                searchQueue.Enqueue(puzzleLeft);
            }
            Puzzle puzzleRight = current.copy();
            if (puzzleRight.moveRight(tile))
            {
                searchQueue.Enqueue(puzzleRight);
            }
        }

        return false;

    }
}