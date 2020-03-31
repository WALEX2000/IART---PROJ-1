using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IDDFSUndo
{

    private int depth;
    //Colors in the puzzle
    private List<TileType> colors;
    private Puzzle puzzle;
    private int numNodes = 0;  //Number of visited Nodes


    //Main funciton of the class, initializes variables and calls the IDDFS function
    public Node search(Puzzle puzzle, int depth)
    {
        this.depth = depth;
        colors = puzzle.puzzleColors();
        this.puzzle = puzzle.copy();

        Node finalNode;

        //Increases the limit by 2 every time the search is not successfull
        for (int limit = 4; limit < depth; limit += 2)
        {
            //If successfull return fnal node
            if ((finalNode = dls(new Node(puzzle, null, 0), limit)) != null)
                return finalNode;
        }

        //If it does not find the solution return null
        return null;
    }


    //Iterative deepening funtion recursive function
    //Returns node with solved puzzle if successfull and null if it does not
    public Node dls(Node current, int limit)
    {
        //Increases the number of visited nodes
        numNodes++;

        //If it finds the solution returns true
        if (current.puzzle.isComplete())
        {
            Debug.Log("Solved in " + numNodes + " nodes");
            current.puzzle = current.puzzle.copy();
            return current;
        }
        //If it reaches the limit, tries with a new depth
        if (limit <= 0) return null;

        Node finalNode;

        //Get all the puzzle neighbors by applying all the operators to all the colors
        foreach (TileType tile in colors)
        {
            //Try to move down and if successfull search resulting node
            if (current.puzzle.moveDown(tile))
            {
                Node node = new Node(current.puzzle, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Down;

                //If it finds the solution return final node
                if ((finalNode = dls(node, limit - 1)) != null)
                {
                    current.puzzle.undoMoveDown(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }

                //Reverts the puzzle to before moving down
                current.puzzle.undoMoveDown(tile);
            }
            // Try to move up and if successfull search resulting node
            if (current.puzzle.moveUp(tile))
            {
                Node node = new Node(current.puzzle, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Up;

                //If it finds the solution return node
                if ((finalNode = dls(node, limit - 1)) != null)
                {
                    current.puzzle.undoMoveUp(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }

                //Reverts the puzzle to before moving up
                current.puzzle.undoMoveUp(tile);
            }
            // Try to move left and if successfull search resulting node
            if (current.puzzle.moveLeft(tile))
            {
                Node node = new Node(current.puzzle, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Left;

                //If it finds the solution return node
                if ((finalNode = dls(node, limit - 1)) != null)
                {
                    current.puzzle.undoMoveLeft(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }

                //Reverts the puzzle to before moving left
                current.puzzle.undoMoveLeft(tile);
            }

            // Try to move right and if successfull search resulting node
            if (current.puzzle.moveRight(tile))
            {
                Node node = new Node(current.puzzle, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Right;

                //If it finds the solution return node
                if ((finalNode = dls(node, limit - 1)) != null)
                {
                    current.puzzle.undoMoveRight(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }

                //Reverts the puzzle to before moving right
                current.puzzle.undoMoveRight(tile);
            }
        }

        return null;

    }


}


