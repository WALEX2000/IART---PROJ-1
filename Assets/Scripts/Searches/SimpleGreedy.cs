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
            Node current = priorityQueue.Dequeue();

            if (current.puzzle.isComplete())
            {
                Debug.Log("Solved");
                return current;
            }

            // if (visited.Contains(current.puzzle.PuzzleMatrix)) continue;
            // visited.Add(current.puzzle.PuzzleMatrix);


            foreach (TileType tile in colors)
            {

                Puzzle puzzleDown = current.puzzle.copy();
                if (puzzleDown.moveDown(tile))
                {
                    priorityQueue.Enqueue(new Node(puzzleDown, current, SimpleGreedy.calculatePuzzleScore(puzzleDown)));
                }
                Puzzle puzzleUp = current.puzzle.copy();

                if (puzzleUp.moveUp(tile))
                {
                    priorityQueue.Enqueue(new Node(puzzleUp, current, SimpleGreedy.calculatePuzzleScore(puzzleUp)));
                }
                Puzzle puzzleLeft = current.puzzle.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    priorityQueue.Enqueue(new Node(puzzleLeft, current, SimpleGreedy.calculatePuzzleScore(puzzleLeft)));
                }
                Puzzle puzzleRight = current.puzzle.copy();
                if (puzzleRight.moveRight(tile))
                {
                    priorityQueue.Enqueue(new Node(puzzleRight, current, SimpleGreedy.calculatePuzzleScore(puzzleRight)));
                }
            }

        }

        return null;
    }
}


