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


//
// [
// [0,0,0,0,0,0]
// [0,9,9,9,9,0]
// [9,9,0,9,9,0]
// [0,9,9,9,0,0]
// [9,9,9,0,0,0]
// [9,0,9,9,0,0]
// ]

public class AStar{

    private int finalScore; //Sum of the start score and the distanceToScore
    private int startScore; //Distance from the starting point
    private int destinationScore; //Distance to the destination
    private List<Puzzle> openList;
    private List<Puzzle> closedList;

    public AStar(Puzzle puzzle){
        openList = new List<Puzzle>();
        closedList = new List<Puzzle>();

    }


    //Deve levar os puzzles como argumentos ou a matriz de scores?
    public int calculateDestinationScore(List<List<int>> currentScoreMatrix, List<List<int>> finalScoreMatrix){
        int finalScore=0,currentScore=0;
        return finalScore - currentScore;
    }

    public int calculateScoreOfMatrix(List<List<int>> scoreMatrix){
        return 0;
    }

    public List<List<int>> calculatePuzzleMatrix(Puzzle puzzle){

        return new List<List<int>>();

    }

    public int calculatestartScore(Puzzle current){
        List<List<int>> initialScore = new List<List<int>>();

        
        return 0;
    }
    public bool search(Puzzle current, List<TileType> colors){
        List<Puzzle> openList = new List<Puzzle>();
        openList.Add(current);

        while(openList.Count > 0){

        }

        return true;

    }

}


   