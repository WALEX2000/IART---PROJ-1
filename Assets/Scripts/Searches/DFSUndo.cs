using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFSUndo
{
    private List<TileType> colors;
    private Puzzle current;
    private HashSet<Puzzle> visited;
    private int numNodes = 0;

    public Node search(Puzzle puzzle)
    {
        visited = new HashSet<Puzzle>();
        colors = puzzle.puzzleColors();
        this.current = puzzle;
        return depthFirstSearchUndo(new Node(current, null, 0));
    }
    public Node depthFirstSearchUndo(Node current)
    {
        numNodes++;
        if (current.puzzle.isComplete())
        {
            current.puzzle = current.puzzle.copy();
            Debug.Log("Solved in " + numNodes + " nodes");
            return current;
        }


        Node finalNode;
        foreach (TileType tile in colors)
        {
            if (current.puzzle.moveDown(tile))
            {
                Node node = new Node(current.puzzle, current, 0);                
                node.movedTile = tile;
                node.moveType = MoveType.Down;                
                if ((finalNode = depthFirstSearchUndo(node)) != null)
                {
                    current.puzzle.undoMoveDown(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }
                current.puzzle.undoMoveDown(tile);
            }

            if (current.puzzle.moveUp(tile))
            {
                Node node = new Node(current.puzzle, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Up;
                if ((finalNode = depthFirstSearchUndo(node)) != null)
                {
                    current.puzzle.undoMoveUp(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }
                current.puzzle.undoMoveUp(tile);
            }

            if (current.puzzle.moveLeft(tile))
            {
                Node node = new Node(current.puzzle, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Left;
                if ((finalNode = depthFirstSearchUndo(node)) != null)
                {
                    current.puzzle.undoMoveLeft(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }
                current.puzzle.undoMoveLeft(tile);
            }

            if (current.puzzle.moveRight(tile))
            {
                Node node = new Node(current.puzzle, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Right;
                if ((finalNode = depthFirstSearchUndo(node)) != null)
                {
                    current.puzzle.undoMoveRight(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }
                current.puzzle.undoMoveRight(tile);
            }
        }

        return null;
    }

}
