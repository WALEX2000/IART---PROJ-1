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

    private List<TileType> colors;
    private PriorityQueue<Node> priorityQueue;
    private HashSet<TileType[][]> visited;
    private int numNodes = 0;


    public Node search(Puzzle puzzle)
    {
        colors = puzzle.puzzleColors();
        priorityQueue = new PriorityQueue<Node>();
        visited = new HashSet<TileType[][]>();

        priorityQueue.Enqueue(new Node(puzzle, null, 0));
        return greedySearch();
    }

    //Preenche primeiro os maiores
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

    //Nao esquecer que o BFS funcionava melhor com uma lista do que com uma queue
    private Node greedySearch()
    {
        while (priorityQueue.Count() != 0)
        {
            numNodes++;
            Node current = priorityQueue.Dequeue();

            if (current.puzzle.isComplete())
            {
                Debug.Log("Solved in " + numNodes + " nodes");
                return current;
            }

            // if (visited.Contains(current.puzzle.PuzzleMatrix)) continue;
            // visited.Add(current.puzzle.PuzzleMatrix);


            foreach (TileType tile in colors)
            {
                Puzzle puzzleDown = current.puzzle.copy();
                if (puzzleDown.moveDown(tile))
                {
                    Node node = new Node(puzzleDown, current, SimpleGreedy.calculatePuzzleScore(puzzleDown));
                    node.movedTile = tile;
                    node.moveType = MoveType.Down;
                    priorityQueue.Enqueue(node);
                }

                Puzzle puzzleUp = current.puzzle.copy();
                if (puzzleUp.moveUp(tile))
                {
                    Node node = new Node(puzzleUp, current, SimpleGreedy.calculatePuzzleScore(puzzleUp));
                    node.movedTile = tile;
                    node.moveType = MoveType.Up;
                    priorityQueue.Enqueue(node);
                }
                Puzzle puzzleLeft = current.puzzle.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    Node node = new Node(puzzleLeft, current, SimpleGreedy.calculatePuzzleScore(puzzleLeft));
                    node.movedTile = tile;
                    node.moveType = MoveType.Left;
                    priorityQueue.Enqueue(node);
                }
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


