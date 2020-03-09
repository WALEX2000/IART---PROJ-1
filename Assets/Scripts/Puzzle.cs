using UnityEngine;
using System;

public enum TileType {Empty, Null, Red, Blue, Green, Yellow}

public class Puzzle : ScriptableObject
{
    public static TileType[][] puzzle1 = new TileType[][]
    {
        new TileType[] {TileType.Red, TileType.Empty, TileType.Null},
        new TileType[] {TileType.Empty, TileType.Empty, TileType.Blue},
        new TileType[] {TileType.Null, TileType.Null, TileType.Empty}
    };
    public TileType[][] puzzleMatrix;

    public Puzzle(TileType[][] matrix) {
        puzzleMatrix = matrix;
    }

    public void displayPuzzle() {

    }
}