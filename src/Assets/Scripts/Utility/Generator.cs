using UnityEngine;
using System;
using System.Linq;
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


    public List<TileType> getColorArray(int range){

        List<TileType> colors = Enum.GetValues(typeof(TileType)).Cast<TileType>().ToList();
        List<TileType> subColors = colors.GetRange(2,range);
        return subColors;
    }

    public TileType getNextTile(int range,int i,int j, TileType[][] matrix){
        TileType random = getRandomTileType(range);
        return random;
    }

    //[B,B,0]
    //[B,B,0]
    //[0,0,0]
    public TileType[][] generatePuzzle(int size,int numberColors){

        //Primeiro tem que se decidir em que eixo e que ela e simetrica tanto em x como y
        //Para cada cor tem que se definir um eixo X e Y

        TileType[][] matrix = new TileType[size][];
        List<TileType> colors = getColorArray(numberColors);

        for (int i = 0; i < size; i++){
            TileType[] line = new TileType[size];
            for (int j = 0; j < size; j++){
                TileType random = getRandomTileType(numberColors);
                int middleX = (size + j)/2;
                int middleY = (size + i)/2;

                //Debug.Log(middleX + " X " + j);
                //Debug.Log(middleY + " Y " + i);


                line[j] = random;
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