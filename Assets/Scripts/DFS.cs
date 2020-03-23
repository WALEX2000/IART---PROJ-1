using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DFS{
    List<TileType> colors;
    Puzzle current;



    public DFS(Puzzle puzzle){
        colors = puzzle.puzzleColors();
        this.current = puzzle;
    }


    public bool search(Puzzle current){

        if(current.isComplete()){   
            current.displayPuzzle();
            return true;
        }

        foreach (TileType tile in colors){ 
            
            Puzzle puzzleDown = current.copy();
            if (puzzleDown.moveDown(tile)){
                // Debug.Log("Moving " + tile + " down");
                if(search(puzzleDown))
                    return true;
            }    

            Puzzle puzzleUp= current.copy();
            if (puzzleUp.moveUp(tile)){
                // Debug.Log("Moving " + tile + " up");
                if(search(puzzleUp))
                    return true;

            }     
            Puzzle puzzleLeft = current.copy();
            if (puzzleLeft.moveLeft(tile)){
                // Debug.Log("Moving " + tile + " left");
                if(search(puzzleLeft))
                    return true;
            }  
            Puzzle puzzleRight = current.copy();
            if (puzzleRight.moveRight(tile)){
                // Debug.Log("Moving " + tile + " right");
                if(search(puzzleRight))
                    return true;
            }
        }
                                
        return false;

    }

}


   