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

    private HashSet<Puzzle> openList;
    private HashSet<Puzzle> closedList;

    private List<TileType> colors;

    private Puzzle current;
    private Puzzle empty;

    private Dictionary<Puzzle, int> g;


    public bool search(Puzzle puzzle)
    {

        openList = new HashSet<Puzzle>();
        closedList = new HashSet<Puzzle>();
        g = new Dictionary<Puzzle, int>();
        colors = puzzle.puzzleColors();
        this.current = puzzle.copy();
        empty = new Puzzle(Example.emptyPuzzle, puzzle.tilePrefab);

        g[puzzle] = 0;

        return aStarSearch();
    }


    //Deve levar os puzzles como argumentos ou a matriz de scores?
    public int calculateDestinationScore(List<List<int>> currentScoreMatrix, List<List<int>> finalScoreMatrix)
    {
        int finalScore = 0, currentScore = 0;
        return finalScore - currentScore;
    }



    private int heuristic(Puzzle puzzle)
    {
        return 0;
    }
    private int calculateWeight(Puzzle puzzle) { return 0; }

    private void actionsNeighbour(Puzzle puzzle)
    {
        g[puzzle] = 0;
        g[current] = 0;
        int weight = calculateWeight(puzzle);

        if (!openList.Contains(puzzle) && (!openList.Contains(puzzle)))
        {
            openList.Add(puzzle);
            g[puzzle] = g[current] + weight;
        }
        else if (g[puzzle] > g[current] + weight)
        {
            g[puzzle] = g[current] + weight;
            if (closedList.Contains(puzzle))
            {
                closedList.Remove(puzzle);
                openList.Add(puzzle);
            }
        }

    }



    private bool aStarSearch()
    {

        openList.Add(current);



        while (openList.Count > 0)
        {
            current = empty;
            g[current] = 0;
            Debug.Log("Cheguei aqui");

            foreach (Puzzle p in openList)
            {
                g[p] = 0;
                if (current == empty || (g[p] + heuristic(p)) < g[current] + heuristic(current))
                {
                    current = p.copy(); //Is the copy really necessary?
                }
            }
            Debug.Log("Cheguei aqui");


            if (current == empty)
            {
                Debug.Log("Path does not exist");
                return false;
            }

            if (current.isComplete())
            {
                current.displayPuzzle();
                Debug.Log("Solved with A*");
                return true;
            }

            Debug.Log("Cheguei aqui");


            foreach (TileType tile in colors)
            {
                Puzzle puzzleDown = current.copy();
                if (puzzleDown.moveDown(tile))
                {
                    actionsNeighbour(puzzleDown);
                }

                Puzzle puzzleUp = current.copy();
                if (puzzleUp.moveUp(tile))
                {
                    actionsNeighbour(puzzleUp);

                }

                Puzzle puzzleLeft = current.copy();
                if (puzzleLeft.moveLeft(tile))
                {
                    actionsNeighbour(puzzleLeft);

                }

                Puzzle puzzleRight = current.copy();
                if (puzzleRight.moveRight(tile))
                {
                    actionsNeighbour(puzzleRight);
                }
            }
            Debug.Log("Cheguei aqui");


            openList.Remove(current);
            closedList.Add(current);
            Debug.Log("Cheguei aqui");

        }

        Debug.Log("Could not find solution");

        return false;

    }

}


