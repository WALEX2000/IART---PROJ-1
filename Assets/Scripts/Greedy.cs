using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//Objective: Do the more unique solutions first
//How
//For a puzzle, expand all colors in four directions
//See what are the moves that result in more unique solutions
//Do those first
public class Greedy{


    private List<TileType> colors;
    private Puzzle current;
    public Greedy(Puzzle puzzle){
        colors = puzzle.puzzleColors();
        this.current = puzzle;
    }


    //Versão ainda muito rudimentar de como calcular
    //Ver os filhos e calcular matriz de score de todas somadas
    public int calculateMatrixScore(Puzzle puzzle){

        List<List<int>> matrix = new List<List<int>>();



        foreach (TileType tile in colors){
            
            Puzzle puzzleDown = current.copy();
            if (puzzleDown.moveDown(tile)){

            }    
            Puzzle puzzleUp =current.copy();
            
            if (puzzleUp.moveUp(tile)){
            }     
            Puzzle puzzleLeft =current.copy();
            if (puzzleLeft.moveLeft(tile)){
            }  
            Puzzle puzzleRight =current.copy();
            if (puzzleRight.moveRight(tile)){

            }        

        }
        return 0;

    }



    //Given a puzzle calculates its matrix
    public List<List<int>> calculateMatrix(Puzzle puzzle){

        List<List<int>> scoreMatrix = new List<List<int>>();

        for (int i = 0; i < puzzle.PuzzleMatrix.Length; i++){
            List<int> scoreLine = new List<int>();
            for (int j = 0; j < puzzle.PuzzleMatrix[0].Length; j++){
                if(puzzle.PuzzleMatrix[i][j] == TileType.Null) scoreLine.Add(0);  //Give Null Elements 0 Points
                else if(puzzle.PuzzleMatrix[i][j] == TileType.Empty) scoreLine.Add(9); //Give Empty Elements 9 pointss
                else scoreLine.Add(1); //Give 1 Point to each color
            }
            scoreMatrix.Add(scoreLine);
        }
 
        return scoreMatrix;
    }


    public int calculatePuzzleScore(Puzzle current){

        int score = 0;
        for (int i = 0; i < current.PuzzleMatrix.Length; i++){
            for (int j = 0; j < current.PuzzleMatrix[0].Length; j++){
                if(current.PuzzleMatrix[i][j] == TileType.Null) continue;  //Give Null Elements 0 Points
                else if(current.PuzzleMatrix[i][j] == TileType.Empty) score+=9; //Give Empty Elements 9 pointss
                else score+=1; //Give 1 Point to each color
            }
        }
        Debug.Log("Matrix score = " + score);
        return score;
    }




}


   