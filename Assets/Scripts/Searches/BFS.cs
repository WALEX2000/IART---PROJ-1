
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BFS
{
    private Queue<Node> searchQueue;
    private List<TileType> colors;
    private Puzzle puzzle;
    private HashSet<Puzzle> visited;



    public Node search(Puzzle puzzle)
    {
        colors = puzzle.puzzleColors();
        visited = new HashSet<Puzzle>();
        this.puzzle = puzzle.copy();
        searchQueue = new Queue<Node>();
        searchQueue.Enqueue(new Node(puzzle, null, 0));
        return breadthFirstSearch();
    }

    private Node breadthFirstSearch()
    {

        while (searchQueue.Count != 0)
        {
            Node current = searchQueue.Dequeue();

            if (current.puzzle.isComplete())
            {
                return current;
            }

            // if (visited.Contains(current.puzzle)) return null;
            // visited.Add(current.puzzle);

            foreach (TileType tile in colors)
            {
                Puzzle puzzleDown = current.puzzle.copy();
                if (puzzleDown.moveDown(tile))
                {
                    searchQueue.Enqueue(new Node(puzzleDown, current, 0));
                }

                Puzzle puzzleUp = current.puzzle.copy();
                if (puzzleUp.moveUp(tile))
                {
                    searchQueue.Enqueue(new Node(puzzleUp, current, 0));
                }

                Puzzle puzzleLeft = current.puzzle.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    searchQueue.Enqueue(new Node(puzzleLeft, current, 0));
                }

                Puzzle puzzleRight = current.puzzle.copy();
                if (puzzleRight.moveRight(tile))
                {
                    searchQueue.Enqueue(new Node(puzzleRight, current, 0));
                }
            }
        }

        return null;
    }
}