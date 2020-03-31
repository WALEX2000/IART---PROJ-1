using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DFS
{
    //Colors in the puzzle
    List<TileType> colors;
    Puzzle current;
    HashSet<Puzzle> visited; //List of visited Nodes
    private int numNodes = 0; //Number of visited Nodes

    //Main funciton of the class, initializes variables and calls the DFS function
    public Node search(Puzzle puzzle)
    {
        visited = new HashSet<Puzzle>();
        colors = puzzle.puzzleColors();
        this.current = puzzle;
        return depthFirstSearch(new Node(current, null, 0));
    }


    //Depth first search recursive funtion
    //Returns node with solved puzzle if successfull and null if it does not
    private Node depthFirstSearch(Node current)
    {
        //Increases the number of visited nodes
        numNodes++;

        //If it finds the solution returns true
        if (current.puzzle.isComplete())
        {
            Debug.Log("Solved in " + numNodes + " nodes");
            return current;
        }
        //If the node has already been visited move on
        if (visited.Contains(current.puzzle)) return null;
        visited.Add(current.puzzle);

        Node finalNode;

        //Get all the puzzle neighbors by applying all the operators to all the colors
        foreach (TileType tile in colors)
        {

            Puzzle puzzleDown = current.puzzle.copy();

            //Try to move down and if successfull search resulting node
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
            //Try to move up and if successfull search resulting node
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
            //Try to move left and if successfull search resulting node
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
            //Try to move right and if successfull search resulting node
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
        //If it does not find the solution returns null
        return null;
    }

}


