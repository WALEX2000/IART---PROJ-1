using UnityEngine;
using System;

public enum TileType {Empty, Null, Red, Blue, Green, Yellow}

public class Puzzle
{
    //HARDCODED PUZZLES//
    public static TileType[][] puzzle1 = new TileType[][]
    {
        new TileType[] {TileType.Red, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Blue},
        new TileType[] {TileType.Null, TileType.Null, TileType.Empty}
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
}