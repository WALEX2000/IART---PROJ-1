using UnityEngine;
using System;
using System.Collections.Generic;

public enum TileType {Empty, Null, Red, Blue, Green, Yellow}

public class Puzzle
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
                    GameObject baseTile = UnityEngine.Object.Instantiate(tilePrefab, new Vector3(i, 0.125f, j), Quaternion.identity); //Base Block Below
                    baseTile.GetComponent<MeshRenderer>().material.color = Color.white;
                          
                    if((int)puzzleMatrix[i][j] > 1) {
                        GameObject instantiatedTile = UnityEngine.Object.Instantiate(tilePrefab, new Vector3(i, 0.375f, j), Quaternion.identity); //Actual Tiles on top                    

                        switch(puzzleMatrix[i][j]) {
                            case TileType.Blue:
                                instantiatedTile.GetComponent<Renderer>().material.color = Color.blue;
                            break;
                            case TileType.Red:
                                instantiatedTile.GetComponent<Renderer>().material.color = Color.red;
                            break;
                            case TileType.Yellow:
                                instantiatedTile.GetComponent<Renderer>().material.color = Color.yellow;
                            break;
                            case TileType.Green:
                                instantiatedTile.GetComponent<Renderer>().material.color = Color.green;
                            break;
                            default:
                                Debug.LogError("Unknown Material for tile: " + puzzleMatrix[i][j]);                        
                            break;
                        }          
                    }
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