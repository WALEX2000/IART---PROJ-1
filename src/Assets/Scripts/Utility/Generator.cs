using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;


public class Generator
{
    //HARDCODED PUZZLES//
    public TileType[][] puzzleEasy1 = new TileType[][]
    {
        new TileType[] {TileType.Red, TileType.Empty, TileType.Null, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Null, TileType.Blue, TileType.Empty}
    };

    public TileType getRandomTileType(int range){
        range += 2;
         return (TileType)Enum.ToObject(typeof(TileType) , UnityEngine.Random.Range(2, range));
    }
    public TileType[][] generatePuzzle(int size,int numberColors){

        TileType[][] matrix = new TileType[size][];

        for (int i = 0; i < size; i++){
            TileType[] line = new TileType[size];
            for (int j = 0; j < size; j++){
                line[j] = getRandomTileType(numberColors);
            }
            matrix[i] = line;
        }
        return matrix;
    }

    


    public void displayConsole(TileType[][] puzzleMatrix)
    {

        string puzzleString = "";
        for (int i = 0; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++)
            {
                puzzleString += puzzleMatrix[i][j] + " ";
            }
            puzzleString += "\n";

        }
        Debug.Log(puzzleString);
    }
}