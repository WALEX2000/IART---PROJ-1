using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DFS
{
    List<TileType> colors;
    Puzzle current;
    HashSet<Puzzle> visited;
    private int numNodes = 0;

    public Node search(Puzzle puzzle)
    {
        visited = new HashSet<Puzzle>();
        colors = puzzle.puzzleColors();
        this.current = puzzle;
        return depthFirstSearch(new Node(current, null, 0));
    }

    private Node depthFirstSearch(Node current)
    {
        numNodes++;
        
        if (current.puzzle.isComplete()) {
            Debug.Log("Solved in " + numNodes + " nodes");
            return current;
        }

        if (visited.Contains(current.puzzle)) return null;
        visited.Add(current.puzzle);

        Node finalNode;
        foreach (TileType tile in colors)
        {
            Puzzle puzzleDown = current.puzzle.copy();
            if (puzzleDown.moveDown(tile))
            {
                Node node = new Node(puzzleDown, current, 0);                
                node.movedTile = tile;
                node.moveType = MoveType.Down;                
                if ((finalNode = depthFirstSearch(node)) != null)
                {
                    return finalNode;
                }
            }

            Puzzle puzzleUp = current.puzzle.copy();
            if (puzzleUp.moveUp(tile))
            {
                Node node = new Node(puzzleUp, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Up;
                if ((finalNode = depthFirstSearch(node)) != null)
                {
                    return finalNode;
                }
            }

            Puzzle puzzleLeft = current.puzzle.copy();
            if (puzzleLeft.moveLeft(tile))
            {
                Node node = new Node(puzzleLeft, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Left;
                if ((finalNode = depthFirstSearch(node)) != null)
                {
                    return finalNode;
                }
            }

            Puzzle puzzleRight = current.puzzle.copy();
            if (puzzleRight.moveRight(tile))
            {
                Node node = new Node(puzzleRight, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Right;
                if ((finalNode = depthFirstSearch(node)) != null)
                {
                    return finalNode;
                }
            }
        }

        return null;
    }

}


