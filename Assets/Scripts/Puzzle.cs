using UnityEngine;
using System;
using System.Collections.Generic;

public enum TileType {Empty, Null, Red, Blue, Green, Yellow}

public class Puzzle : ScriptableObject
{
    //HARDCODED PUZZLES//
    public static TileType[][] puzzle1 = new TileType[][]
    {
        new TileType[] {TileType.Red, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Null, TileType.Blue, TileType.Blue}
    };
    //HARDCODED PUZZLES//
    private GameObject tilePrefab;
    private TileType[][] puzzleMatrix;
    public Puzzle(TileType[][] matrix, GameObject tilePrefab) {
        puzzleMatrix = matrix;
        this.tilePrefab = tilePrefab;
    }

    public void displayPuzzle() {
        for(int i = 0; i < puzzleMatrix.Length; i++) {
            for(int j = 0; j < puzzleMatrix[i].Length; j++) {
                if(puzzleMatrix[i][j] != TileType.Null) {
                    Instantiate(tilePrefab, new Vector3(i, 0.125f, i), Quaternion.identity); //Base Block Below
                    Instantiate(tilePrefab, new Vector3(i, 0.375f, i), Quaternion.identity); //Actual Tiles on top
                }
            }
        }
    }

    public bool moveUp(TileType tile){
        int rotationAxis = puzzleMatrix.Length;
        bool foundAxis = false;
        for (int i = 0; (i < puzzleMatrix.Length) && (!foundAxis); i++){
            for (int j = 0; j < puzzleMatrix[i].Length; j++){
                
                // Discovers what is the rotation axis
                if(puzzleMatrix[i][j] == tile){
                    rotationAxis = i;
                    foundAxis = true;
                    break;
                }                
            }
        }

        List<Tuple<int,int>> positions = new List<Tuple<int,int>>() ;

    
        for (int i = rotationAxis; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++){
                Debug.Log(i + " " + j);
                if (tile == puzzleMatrix[i][j]){
                    int symetricY =(2*rotationAxis-i-1);
                    if(canMove(symetricY,j)){
                        positions.Add(Tuple.Create(symetricY,j));
                    } else return false;
                }
            }
        }

        for (int i = 0; i < positions.Count; i++){
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }

        return true;

        // Tile tem que ser uma cor 
        // Ver se nao sobrepoe nem se sai do tabule nem emoty nem null
    }

    public bool canMove(int i , int j){
        if(i < puzzleMatrix.Length && j < puzzleMatrix[i].Length && puzzleMatrix[i][j] == TileType.Empty) return true;
        return false;
    }

    
    public void displayConsole(){
        string puzzleString="";
        for (int i = 0; i < puzzle1.Length; i++)
        {
            for (int j = 0; j < puzzle1[i].Length; j++)
            {
                puzzleString+=puzzle1[i][j] + " ";
            }            
        }
        Debug.Log(puzzleString);
    }
}