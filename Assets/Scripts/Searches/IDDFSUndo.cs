using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IDDFSUndo
{

    private int depth;
    private List<TileType> colors;
    private Puzzle puzzle;
    private int numNodes = 0;


    public Node search(Puzzle puzzle, int depth)
    {
        this.depth = depth;
        colors = puzzle.puzzleColors();
        this.puzzle = puzzle.copy();

        Node finalNode;
        for (int limit = 4; limit < depth; limit+=2)
        {
            if ((finalNode = dls(new Node(puzzle, null, 0), limit)) != null)
                return finalNode;
        }
        return null;
    }

    public Node dls(Node current, int limit)
    {
        numNodes++;

        if (current.puzzle.isComplete())
        {
            Debug.Log("Solved in " + numNodes + " nodes");
            current.puzzle = current.puzzle.copy();
            return current;
        }

        if (limit <= 0) return null;

        Node finalNode;
        foreach (TileType tile in colors)
        {

            if (current.puzzle.moveDown(tile))
            {
                if ((finalNode = dls(new Node(current.puzzle, current, 0), limit - 1)) != null) {
                    current.puzzle.undoMoveDown(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }
                current.puzzle.undoMoveDown(tile);
            }
            if (current.puzzle.moveUp(tile))
            {
                if ((finalNode = dls(new Node(current.puzzle, current, 0), limit - 1)) != null) {
                    current.puzzle.undoMoveUp(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }
                current.puzzle.undoMoveUp(tile);
            }
            if (current.puzzle.moveLeft(tile))
            {
                if ((finalNode = dls(new Node(current.puzzle, current, 0), limit - 1)) != null) {
                    current.puzzle.undoMoveLeft(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }
                current.puzzle.undoMoveLeft(tile);
            }
            if (current.puzzle.moveRight(tile))
            {
                if ((finalNode = dls(new Node(current.puzzle, current, 0), limit - 1)) != null) {
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


