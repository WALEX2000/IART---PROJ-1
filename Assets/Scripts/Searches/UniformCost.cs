using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//Objective: Do the more unique solutions first
//How
//For a puzzle, expand all colors in four directions
//See what are the moves that result in more unique solutions
//Do those first
public class UniformCost
{

    private List<TileType> colors;
    private PriorityQueue<Node> priorityQueue;


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

    public Node search(Puzzle puzzle) {
        colors = puzzle.puzzleColors();
        priorityQueue = new PriorityQueue<Node>();
        priorityQueue.Enqueue(new Node(puzzle, null, 0));
        return uniformCost();
    }


    public Node uniformCost()
    {
        while (priorityQueue.Count() != 0)
        {
            Node current = priorityQueue.Dequeue();

            if (current.puzzle.isComplete())
            {
                return current;
            }

            foreach (TileType tile in colors)
            {
                Puzzle puzzleDown = current.puzzle.copy();
                if (puzzleDown.moveDown(tile))
                {
                    priorityQueue.Enqueue(new Node(puzzleDown, current, UniformCost.calculatePuzzleScore(puzzleDown)));
                }
                Puzzle puzzleUp = current.puzzle.copy();

                if (puzzleUp.moveUp(tile))
                {
                    priorityQueue.Enqueue(new Node(puzzleUp, current, UniformCost.calculatePuzzleScore(puzzleUp)));
                }
                Puzzle puzzleLeft = current.puzzle.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    priorityQueue.Enqueue(new Node(puzzleLeft, current, UniformCost.calculatePuzzleScore(puzzleLeft)));
                }
                Puzzle puzzleRight = current.puzzle.copy();
                if (puzzleRight.moveRight(tile))
                {
                    priorityQueue.Enqueue(new Node(puzzleRight, current, UniformCost.calculatePuzzleScore(puzzleRight)));
                }
            }

        }

        return null;
    }

}


