using UnityEngine;
using System;

public enum TileType {Empty, Null, Red, Blue, Green, Yellow}

[CreateAssetMenu(fileName = "New Puzzle", menuName = "Puzzle")]
public class Puzzle : ScriptableObject
{
    public TileTypeList[] puzzleMatrix;

    public void generatePuzzle() {

    }
}

[Serializable]
public class TileTypeList {
    public TileType[] tileList;
}