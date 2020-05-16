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

    public TileType getRandomTileType(){
        Array values = TileType.GetValues(typeof(String));
        System.Random random = new System.Random();
        return (TileType)values.GetValue(random.Next(values.Length));
    }
}