using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : IComparable<Move>
{
    public int score;
    public List<Tuple<int, int>> positions;
    public TileType tile;
    public Move(List<Tuple<int, int>> positions, TileType tile)
    {
        this.positions = positions;
        this.score = 0;
        this.tile = tile;
    }
    public void setScore(int newScore) { this.score = newScore; }
    public void addOne() { score++; }

    public int CompareTo(Move other)
    {
        if (this.score > other.score) return 1;
        else if (this.score < other.score) return -1;
        else return 0;
    }
}