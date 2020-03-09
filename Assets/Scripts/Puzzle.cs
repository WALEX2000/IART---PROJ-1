using UnityEngine;
using System;
using System.Collections.Generic;

public enum TileType {Empty, Null, Red, Blue, Green, Yellow}

public class Puzzle
{
    //HARDCODED PUZZLES//
    public static TileType[][] puzzle1 = new TileType[][]
    {
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Blue},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Blue, TileType.Blue},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Blue},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty},
        new TileType[] {TileType.Red, TileType.Empty, TileType.Empty, TileType.Empty, TileType.Empty}
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

        //Discover the rotation axis
        for (int i = 0; (i < puzzleMatrix.Length) && (!foundAxis); i++){
            for (int j = 0; j < puzzleMatrix[i].Length; j++){

                if(puzzleMatrix[i][j] == tile){
                    rotationAxis = i;
                    foundAxis = true;
                    break;
                }                
            }
        }

        List<Tuple<int,int>> positions = new List<Tuple<int,int>>() ;

        //Discovers if all the elements can rotate
        //Adds positions of the tiles to a List
        for (int i = rotationAxis; i < puzzleMatrix.Length; i++)
        {
            for (int j = 0; j < puzzleMatrix[i].Length; j++){
                if (tile == puzzleMatrix[i][j]){
                    int symetricX =i-2*(i-rotationAxis)-1;  
                    if(canMove(symetricX,j)){
                        positions.Add(Tuple.Create(symetricX,j));
                    } else return false;
                }
            }
        }

        //If they can all move, change the colors
        for (int i = 0; i < positions.Count; i++){
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }

        return true;
    }

    public bool moveDown(TileType tile){

        int rotationAxis = -1;
        bool foundAxis = false;

        //Discover the rotation axis
        for (int i = puzzleMatrix.Length-1; (i >= 0) && (!foundAxis); i--){
            for (int j = 0; j < puzzleMatrix[i].Length; j++){
                if(puzzleMatrix[i][j] == tile){
                    rotationAxis = i;
                    foundAxis = true;
                    break;
                }                
            }
        }

        List<Tuple<int,int>> positions = new List<Tuple<int,int>>() ;

        //Discovers if all the elements can rotate
        //Adds positions of the tiles to a List
        for (int i = 0; i < puzzleMatrix.Length; i++){
            for (int j = 0; j < puzzleMatrix[i].Length; j++){
                if (tile == puzzleMatrix[i][j]){
                    int symetricX =i+2*(rotationAxis-i)+1;  
                    if(canMove(symetricX,j)){

                        positions.Add(Tuple.Create(symetricX,j));
                    } else return false;
                }
            }
        }

        //If they can all move, change the colors
        for (int i = 0; i < positions.Count; i++){
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }

        return true;
    }

     public bool moveRight(TileType tile){

        int rotationAxis = -1;

        //Discover the rotation axis
        for (int i = 0; i < puzzleMatrix.Length; i++){
            for (int j = puzzleMatrix[i].Length-1; (j >= 0); j--){
                if(puzzleMatrix[i][j] == tile && j > rotationAxis){
                    rotationAxis = j;
                }                
            }
        }

        List<Tuple<int,int>> positions = new List<Tuple<int,int>>() ;

        //Discovers if all the elements can rotate
        //Adds positions of the tiles to a List
        for (int i = 0; i < puzzleMatrix.Length; i++){
            for (int j = 0; j < puzzleMatrix[i].Length; j++){
                if (tile == puzzleMatrix[i][j]){
                    int symetricY =j+2*(rotationAxis-j)+1;  
                    if(canMove(i,symetricY)){
                        positions.Add(Tuple.Create(i,symetricY));
                    } else return false;
                }
            }
        }

        //If they can all move, change the colors
        for (int i = 0; i < positions.Count; i++){
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }

        return true;
    }

        public bool moveLeft(TileType tile){

        int rotationAxis = puzzleMatrix.Length;

        //Discover the rotation axis
        for (int i = 0; i < puzzleMatrix.Length; i++){
            for (int j = 0; j < puzzleMatrix.Length; j++){
                if(puzzleMatrix[i][j] == tile && j < rotationAxis){
                    rotationAxis = j;
                }                
            }
        }

        List<Tuple<int,int>> positions = new List<Tuple<int,int>>() ;

        //Discovers if all the elements can rotate
        //Adds positions of the tiles to a List
        for (int i = 0; i < puzzleMatrix.Length; i++){
            for (int j = 0; j < puzzleMatrix[i].Length; j++){
                if (tile == puzzleMatrix[i][j]){
                    int symetricY =j-2*(j-rotationAxis)-1;  
                    if(canMove(i,symetricY)){
                        positions.Add(Tuple.Create(i,symetricY));
                    } else return false;
                }
            }
        }

        //If they can all move, change the colors
        for (int i = 0; i < positions.Count; i++){
            puzzleMatrix[positions[i].Item1][positions[i].Item2] = tile;
        }

        return true;
    }

    public bool canMove(int i , int j){
        if(i < puzzleMatrix.Length && i >= 0){
            if(j >= 0 && j < puzzleMatrix[i].Length){
                if(puzzleMatrix[i][j] == TileType.Empty) return true;
            }
        }
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