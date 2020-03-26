using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DFS
{
    List<TileType> colors;
    Puzzle current;
    HashSet<Puzzle> visited;

    public Node search(Puzzle puzzle)
    {
        visited = new HashSet<Puzzle>();
        colors = puzzle.puzzleColors();
        this.current = puzzle;
        return depthFirstSearch(new Node(current, null, 0));
    }

    private Node depthFirstSearch(Node current)
    {
        if (current.puzzle.isComplete()) return current;

        if (visited.Contains(current.puzzle)) return null;
        visited.Add(current.puzzle);

        Node finalNode;
        foreach (TileType tile in colors)
        {
            Puzzle puzzleDown = current.puzzle.copy();
            if (puzzleDown.moveDown(tile))
            {
                if ((finalNode = depthFirstSearch(new Node(puzzleDown, current, 0))) != null)
                {
                    return finalNode;
                }
            }

            Puzzle puzzleUp = current.puzzle.copy();
            if (puzzleUp.moveUp(tile))
            {
                if ((finalNode = depthFirstSearch(new Node(puzzleUp, current, 0))) != null)
                {
                    return finalNode;
                }
            }

            Puzzle puzzleLeft = current.puzzle.copy();
            if (puzzleLeft.moveLeft(tile))
            {
                if ((finalNode = depthFirstSearch(new Node(puzzleLeft, current, 0))) != null)
                {
                    return finalNode;
                }
            }

            Puzzle puzzleRight = current.puzzle.copy();
            if (puzzleRight.moveRight(tile))
            {
                if ((finalNode = depthFirstSearch(new Node(puzzleRight, current, 0))) != null)
                {
                    return finalNode;
                }
            }
        }

        return null;
    }

}


