using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IDDFSUndo
{

    private int depth;
    private List<TileType> colors;
    private Puzzle puzzle;


    public bool search(Puzzle puzzle, int depth)
    {
        this.depth = depth;
        colors = puzzle.puzzleColors();
        this.puzzle = puzzle.copy();

        for (int limit = 0; limit < depth; limit++)
        {
            if (dls(puzzle, limit))
                return true;
        }
        return false;
    }

    public bool dls(Puzzle current, int limit)
    {

        if (current.isComplete())
        {
            current.displayPuzzle();
            Debug.Log("ZAS");
            return true;
        }

        if (limit <= 0) return false;

        foreach (TileType tile in colors)
        {

            if (current.moveDown(tile))
            {
                if (dls(current, limit - 1))
                    return true;
                current.undoMoveDown(tile);
            }
            if (current.moveUp(tile))
            {
                if (dls(current, limit - 1))
                    return true;
                current.undoMoveUp(tile);
            }
            if (current.moveLeft(tile))
            {
                if (dls(current, limit - 1))
                    return true;
                current.undoMoveLeft(tile);
            }
            if (current.moveRight(tile))
            {
                if (dls(current, limit - 1))
                    return true;
                current.undoMoveRight(tile);
            }
        }

        return false;

    }


}


