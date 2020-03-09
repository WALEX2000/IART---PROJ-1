using UnityEngine;
using System;

public enum TileType {Empty, Null, Red, Blue, Green, Yellow}

public class Puzzle : ScriptableObject
{
    private static TileType[][] puzzle1 =
    {
        {TileType.Red, TileType.Empty, TileType.Null},
        {TileType.Empty, TileType.Empty, TileType.Blue},
        {TileType.Null, TileType.Null, TileType.Empty}
    };

    public TileType[][] puzzleMatrix;

    public void generatePuzzle() {

    }
}