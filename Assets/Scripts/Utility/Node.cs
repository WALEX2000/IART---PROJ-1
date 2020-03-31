using System;
using System.Collections;
using System.Collections.Generic;

public enum MoveType { NULL, Up, Down, Left, Right }
public class Node : IComparable<Node>
{
    public Puzzle puzzle;
    public Node parent;
    public int value;
    public TileType movedTile;
    public MoveType moveType;
    public Node(Puzzle puzzle, Node parent, int value) {
        this.puzzle = puzzle;
        this.parent = parent;
        this.value = value;
    }

    public List<Node> getPath() {
        Node current = this;
        List<Node> path = new List<Node>();
        while(current != null) {
            path.Add(current);
            current = current.parent;
        }
        path.Reverse();
        return path;
    }

    public int CompareTo(Node other)
    {
        if (this.value > other.value) return -1;
        else if (this.value < other.value) return 1;
        else return 0;
    }
}