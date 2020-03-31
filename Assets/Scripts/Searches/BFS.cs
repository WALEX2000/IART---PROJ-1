
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
                Debug.Log("Completed puzzle");
                return current;
            }

            if (visited.Contains(current.puzzle)) continue;
            visited.Add(current.puzzle);

            foreach (TileType tile in colors)
            {
                Puzzle puzzleDown = current.puzzle.copy();
                if (puzzleDown.moveDown(tile))
                {
                    Node node = new Node(puzzleDown, current, 0);
                    node.movedTile = tile;
                    node.moveType = MoveType.Down;
                    searchQueue.Enqueue(node);
                }

                Puzzle puzzleUp = current.puzzle.copy();
                if (puzzleUp.moveUp(tile))
                {
                    Node node = new Node(puzzleUp, current, 0);
                    node.movedTile = tile;
                    node.moveType = MoveType.Up;
                    searchQueue.Enqueue(node);
                }

                Puzzle puzzleLeft = current.puzzle.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    Node node = new Node(puzzleLeft, current, 0);
                    node.movedTile = tile;
                    node.moveType = MoveType.Left;
                    searchQueue.Enqueue(node);
                }

                Puzzle puzzleRight = current.puzzle.copy();
                if (puzzleRight.moveRight(tile))
                {
                    Node node = new Node(puzzleRight, current, 0);
                    node.movedTile = tile;
                    node.moveType = MoveType.Right;
                    searchQueue.Enqueue(node);
                }
            }
        }

        return null;
    }
}