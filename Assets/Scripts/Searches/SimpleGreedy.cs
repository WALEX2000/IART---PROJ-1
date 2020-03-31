using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//Objective: Do the more unique solutions first
//How
//For a puzzle, expand all colors in four directions
//See what are the moves that result in more unique solutions
//Do those first
public class SimpleGreedy
{

    //Colors in the puzzle
    private List<TileType> colors;
    private PriorityQueue<Node> priorityQueue;
    private HashSet<TileType[][]> visited; //List of visited Nodes
    private int numNodes = 0; //Number of visited Nodes


    //Main funciton of the class, initializes variables and calls the Greedy algorithm
    public Node search(Puzzle puzzle)
    {
        colors = puzzle.puzzleColors();
        priorityQueue = new PriorityQueue<Node>();
        visited = new HashSet<TileType[][]>();

        priorityQueue.Enqueue(new Node(puzzle, null, 0));
        return greedySearch();
    }

    //Given a puzzle returns the score correspondent to the number of the filled positions of the puzzle
    public static int calculatePuzzleScore(Puzzle current)
    {
        int score = 0;
        for (int i = 0; i < current.PuzzleMatrix.Length; i++)
        {
            for (int j = 0; j < current.PuzzleMatrix[0].Length; j++)
            {
                if (current.PuzzleMatrix[i][j] != TileType.Null && current.PuzzleMatrix[i][j] != TileType.Empty) score += 1;
            }
        }
        return score;
    }

    //Greedy algoritm function
    //Returns node with solved puzzle if successfull and null if it does not
    private Node greedySearch()
    {
        while (priorityQueue.Count() != 0)
        {
            //Increases the number of visited nodes
            numNodes++;

            //Gets the first element of the priority queue
            Node current = priorityQueue.Dequeue();

            //If it finds the solution returns true
            if (current.puzzle.isComplete())
            {
                Debug.Log("Solved in " + numNodes + " nodes");
                return current;
            }

            //Get all the puzzle neighbors by applying all the operators to all the colors
            foreach (TileType tile in colors)
            {

                //Try to move down and if successfull add to queue
                Puzzle puzzleDown = current.puzzle.copy();
                if (puzzleDown.moveDown(tile))
                {
                    Node node = new Node(puzzleDown, current, SimpleGreedy.calculatePuzzleScore(puzzleDown));
                    node.movedTile = tile;
                    node.moveType = MoveType.Down;
                    priorityQueue.Enqueue(node);
                }

                //Try to move up and if successfull add to queue
                Puzzle puzzleUp = current.puzzle.copy();
                if (puzzleUp.moveUp(tile))
                {
                    Node node = new Node(puzzleUp, current, SimpleGreedy.calculatePuzzleScore(puzzleUp));
                    node.movedTile = tile;
                    node.moveType = MoveType.Up;
                    priorityQueue.Enqueue(node);
                }

                //Try to move left and if successfull add to queue
                Puzzle puzzleLeft = current.puzzle.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    Node node = new Node(puzzleLeft, current, SimpleGreedy.calculatePuzzleScore(puzzleLeft));
                    node.movedTile = tile;
                    node.moveType = MoveType.Left;
                    priorityQueue.Enqueue(node);
                }

                //Try to move right and if successfull add to queue
                Puzzle puzzleRight = current.puzzle.copy();
                if (puzzleRight.moveRight(tile))
                {
                    Node node = new Node(puzzleRight, current, SimpleGreedy.calculatePuzzleScore(puzzleRight));
                    node.movedTile = tile;
                    node.moveType = MoveType.Right;
                    priorityQueue.Enqueue(node);
                }
            }

        }

        return null;
    }
}


