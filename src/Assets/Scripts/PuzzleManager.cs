using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleManager : MonoBehaviour {
    public abstract Puzzle generatePuzzle();

    public abstract void displayPuzzle(Puzzle puzzle, Transform puzzleTransform);

    public abstract void addStep(Node step);

    public abstract void showResult();
}