using UnityEngine;
using System;

public enum TileType {Empty, Null, Red, Blue, Green, Yellow}

public class Puzzle : ScriptableObject
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
                    Instantiate(tilePrefab, new Vector3(i, 0.125f, i), Quaternion.identity); //Base Block Below
                    Instantiate(tilePrefab, new Vector3(i, 0.375f, i), Quaternion.identity); //Actual Tiles on top
                }
            }
        }
    }
}