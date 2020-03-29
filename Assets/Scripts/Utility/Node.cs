using System;
using System.Collections;
using System.Collections.Generic;

public class Node : IComparable<Node>
{
    public Puzzle puzzle;
    public Node parent;
    public int value;

    public Node(Puzzle puzzle, Node parent, int value) {
        this.puzzle = puzzle;
        this.parent = parent;
        this.value = value;
    }

    public List<Puzzle> getPath() {
        Node current = this;
        List<Puzzle> path = new List<Puzzle>();
        while(current != null) {
            path.Add(current.puzzle);
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