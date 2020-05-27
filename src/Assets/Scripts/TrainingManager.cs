using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrainingManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public List<TileType[][]> puzzleMatrixList = new List<TileType[][]>();

    //public Transform testTransform;
    public void Start() {
        //EASY
        //puzzleMatrixList.Add(Example.puzzleRl1);
        //puzzleMatrixList.Add(Example.puzzleRl2);
        //puzzleMatrixList.Add(Example.puzzleRl3);
        //EASY_TEST
        //puzzleMatrixList.Add(Example.puzzleRlTestEasy);

        //MEDIUM
        puzzleMatrixList.Add(Example.puzzleNNmedium1);
        puzzleMatrixList.Add(Example.puzzleNNmedium2);
        puzzleMatrixList.Add(Example.puzzleNNmedium3);
        //MEDIUM_TEST
        //puzzleMatrixList.Add(Example.puzzleNNmediumTest);

        //HARD
        //puzzleMatrixList.Add(Example.puzzleNNhard1);
        //puzzleMatrixList.Add(Example.puzzleNNhard2);
        //puzzleMatrixList.Add(Example.puzzleNNhard3);
        //Hard_TEST
        //puzzleMatrixList.Add(Example.puzzleNNhardTest);

        //displayPuzzle(generatePuzzle(), testTransform); //DEBUG
    }

    public Puzzle generatePuzzle() {
        if(puzzleMatrixList.Count == 0) return null;

        int randPos = UnityEngine.Random.Range(0,puzzleMatrixList.Count);
        TileType[][] puzzleMatrix = puzzleMatrixList[randPos];

        return new Puzzle(puzzleMatrix, tilePrefab);
    }

    public void displayPuzzle(Puzzle puzzle, Transform puzzleTransform) {
        //Delete all children of the puzzleTransform
        /*
        foreach(Transform child in puzzleTransform) {
            Destroy(child.gameObject);
        }

        puzzle.displayPuzzle(puzzleTransform);
        */
        puzzle.startPuzzle();
    }
}