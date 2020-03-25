using System;
using System.Collections;

public class Node {
    private Puzzle puzzle;
    private Node parent;
    private int value;

    public Node(Puzzle puzzle, Node parent, int value) {
        this.puzzle = puzzle;
        this.parent = parent;
        this.value = value;
    }

    public getPuzzle() {
        return this.puzzle;
    }
}