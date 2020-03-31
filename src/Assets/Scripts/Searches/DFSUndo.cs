using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFSUndo
{
    //Colors in the puzzle
    private List<TileType> colors;
    private Puzzle current;
    private HashSet<Puzzle> visited; //List of visited Nodes
    private int numNodes = 0; //Number of visited Nodes

    //Main funciton of the class, initializes variables and calls the DFS function
    public Node search(Puzzle puzzle)
    {
        visited = new HashSet<Puzzle>();
        colors = puzzle.puzzleColors();
        this.current = puzzle;
        return depthFirstSearchUndo(new Node(current, null, 0));
    }

    //Depth first search recursive function
    //Returns node with solved puzzle if successfull and null if it does not
    public Node depthFirstSearchUndo(Node current)
    {
        //Increases the number of visited nodes
        numNodes++;

        //If it finds the solution returns true
        if (current.puzzle.isComplete())
        {
            current.puzzle = current.puzzle.copy();
            Debug.Log("Solved in " + numNodes + " nodes");
            return current;
        }


        Node finalNode;

        //Get all the puzzle neighbors by applying all the operators to all the colors
        foreach (TileType tile in colors)
        {

            // Try to move down and if successfull search resulting node
            if (current.puzzle.moveDown(tile))
            {
                Node node = new Node(current.puzzle, current, 0);
                node.movedTile = tile;
                node.moveType = MoveType.Down;

                //If it finds the solution return node
                if ((finalNode = depthFirstSearchUndo(node)) != null)
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
                if ((finalNode = depthFirstSearchUndo(node)) != null)
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
                if ((finalNode = depthFirstSearchUndo(node)) != null)
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
                if ((finalNode = depthFirstSearchUndo(node)) != null)
                {
                    current.puzzle.undoMoveRight(tile);
                    current.puzzle = current.puzzle.copy();
                    return finalNode;
                }

                //Reverts the puzzle to before moving right
                current.puzzle.undoMoveRight(tile);
            }
        }
        //If it does not find the solution returns null
        return null;
    }

}
