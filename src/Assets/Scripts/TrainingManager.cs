using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrainingManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public List<TileType[][]> puzzleMatrixList = new List<TileType[][]>();

    public void Start() {
        puzzleMatrixList.Add(Example.puzzleEasy1);
        puzzleMatrixList.Add(Example.puzzleEasy2);
        puzzleMatrixList.Add(Example.puzzleEasy3);
    }

    public Puzzle generatePuzzle() {
        if(puzzleMatrixList.Count == 0) return null;

        int randPos = UnityEngine.Random.Range(0,puzzleMatrixList.Count - 1);
        TileType[][] puzzleMatrix = puzzleMatrixList[randPos];

        return new Puzzle(puzzleMatrix, tilePrefab);
    }

    public void displayPuzzle(Puzzle puzzle, Transform puzzleTransform) {
        //Deletes all children of the puzzleTransform
        //Runs the display function with the offset of the puzzleTransform
    }
}