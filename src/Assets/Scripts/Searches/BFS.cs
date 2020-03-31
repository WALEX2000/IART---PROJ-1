
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BFS
{
    private Queue<Node> searchQueue;
    //Colors in the puzzle
    private List<TileType> colors;
    private Puzzle puzzle;
    private HashSet<Puzzle> visited; //List of visited Nodes
    private int numNodes = 0; //Number of visited Nodes

    //Main funciton of the class, initializes variables and calls main cycle
    public Node search(Puzzle puzzle)
    {
        colors = puzzle.puzzleColors();
        visited = new HashSet<Puzzle>();
        this.puzzle = puzzle.copy();
        searchQueue = new Queue<Node>();
        searchQueue.Enqueue(new Node(puzzle, null, 0));
        return breadthFirstSearch();
    }

    //Breadth first search cycle
    //Returns node with solved puzzle if successfull and null if it does not
    private Node breadthFirstSearch()
    {
        while (searchQueue.Count != 0)
        {
            //Increases the number of visited nodes
            numNodes++;

            //Gets the first element of the queue
            Node current = searchQueue.Dequeue();

            //If it finds the solution returns true
            if (current.puzzle.isComplete())
            {
                Debug.Log("Solved in " + numNodes + " nodes");
                return current;
            }

            //If the node has already been visited move on
            if (visited.Contains(current.puzzle)) continue;
            visited.Add(current.puzzle);


            //Get all the puzzle neighbors by applying all the operators to all the colors
            foreach (TileType tile in colors)
            {

                //Try to move down and if successfull add to queue
                Puzzle puzzleDown = current.puzzle.copy();
                if (puzzleDown.moveDown(tile))
                {
                    Node node = new Node(puzzleDown, current, 0);
                    node.movedTile = tile;
                    node.moveType = MoveType.Down;
                    searchQueue.Enqueue(node);
                }
                //Try to move up and if successfull add to queue
                Puzzle puzzleUp = current.puzzle.copy();
                if (puzzleUp.moveUp(tile))
                {
                    Node node = new Node(puzzleUp, current, 0);
                    node.movedTile = tile;
                    node.moveType = MoveType.Up;
                    searchQueue.Enqueue(node);
                }

                //Try to move Left and if successfull add to queue
                Puzzle puzzleLeft = current.puzzle.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    Node node = new Node(puzzleLeft, current, 0);
                    node.movedTile = tile;
                    node.moveType = MoveType.Left;
                    searchQueue.Enqueue(node);
                }

                //Try to move right and if successfull add to queue
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

        //If it does not find the solution returns null
        return null;
    }
}