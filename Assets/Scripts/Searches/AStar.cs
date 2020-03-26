using System.Collections.Generic;
using UnityEngine;





//  {TileType.Null, TileType.Green, TileType.Null, TileType.Null, TileType.Null, TileType.Null},
//  {TileType.Green, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Null},
//  {TileType.Empty, TileType.Empty, TileType.Yellow, TileType.Empty, TileType.Empty, TileType.Null},
//  {TileType.Blue, TileType.Empty, TileType.Empty, TileType.Empty,TileType.Magenta, TileType.Null},
//  {TileType.Empty, TileType.Empty, TileType.Gray, TileType.Empty, TileType.Magenta, TileType.Magenta},
//  {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Magenta, TileType.Magenta, TileType.Magenta},
//  {TileType.Empty, TileType.Red, TileType.Empty, TileType.Empty, TileType.Null, TileType.Null}

//Matriz em que os Empty sao inicializados a 9
//Cada elemento da matriz diz quantas cores sobrepuseram o elemento
//Começar com as mais unicas
//Que estados expandimos inicialmente?
//

public class AStar
{

    private int finalScore; //Sum of the start score and the distanceToScore
    private int startScore; //Distance from the starting point
    private int destinationScore; //Distance to the destination
    private PriorityQueue<Puzzle> openList;
    private HashSet<Puzzle> closedList;

    private List<TileType> colors;

    private Puzzle puzzle;




    public bool search(Puzzle puzzle)
    {

        openList = new PriorityQueue<Puzzle>();
        closedList = new HashSet<Puzzle>();
        colors = puzzle.puzzleColors();
        this.puzzle = puzzle.copy();

        return aStarSearch();
    }


    //Deve levar os puzzles como argumentos ou a matriz de scores?
    public int calculateDestinationScore(List<List<int>> currentScoreMatrix, List<List<int>> finalScoreMatrix)
    {
        int finalScore = 0, currentScore = 0;
        return finalScore - currentScore;
    }

    private int g(Puzzle puzzle)
    {
        return 0;
    }

    private int h(Puzzle puzzle)
    {
        return 0;
    }
    private int f(Puzzle puzzle)
    {
        return g(puzzle) + h(puzzle);
    }
    private int distance(Puzzle p1, Puzzle p2)
    {
        return 0;
    }



    private bool aStarSearch()
    {

        while (openList.Count() != 0)
        {
            Puzzle current = openList.Dequeue();

            if (current.isComplete()) return true;

            if (closedList.Contains(current)) continue;

            closedList.Add(current);

            foreach (TileType tile in colors)
            {
                Puzzle puzzleDown = current.copy();
                if (puzzleDown.moveDown(tile))
                {
                    int cost = g(current) + distance(current, puzzleDown);

                    openList.Enqueue(puzzleDown);
                }

                Puzzle puzzleUp = current.copy();
                if (puzzleUp.moveUp(tile))
                {
                    openList.Enqueue(puzzleUp);
                }

                Puzzle puzzleLeft = current.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    openList.Enqueue(puzzleLeft);
                }

                Puzzle puzzleRight = current.copy();
                if (puzzleRight.moveRight(tile))
                {
                    openList.Enqueue(puzzleRight);
                }
            }
        }

        return false;

    }

}


