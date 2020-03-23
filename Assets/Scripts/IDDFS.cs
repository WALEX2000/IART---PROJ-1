using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IDDFS{

    private int depth;
    private List<TileType> colors;
    private Puzzle puzzle;


    public IDDFS(Puzzle puzzle,int depth){
        this.depth = depth;
        colors = puzzle.puzzleColors();
        this.puzzle = puzzle.copy();
    }

    public bool search(){

        for (int limit = 0; limit < depth; limit++){
            if(dls(puzzle,limit))
                return true;
        }
        return false;
    }

     public bool dls(Puzzle current,int limit){

        if(current.isComplete()){   
            current.displayPuzzle();
            return true;
        }

        if(limit <= 0) return false;

        foreach (TileType tile in colors){ 

            Puzzle puzzleDown = current.copy();
            if (puzzleDown.moveDown(tile)){
                Debug.Log("Moving " + tile + " down");
                if(dls(puzzleDown,limit-1))
                    return true;
            }    

            Puzzle puzzleUp= current.copy();
            if (puzzleUp.moveUp(tile)){
                Debug.Log("Moving " + tile + " up");
                if(dls(puzzleUp,limit-1))
                    return true;

            }     
            Puzzle puzzleLeft = current.copy();
            if (puzzleLeft.moveLeft(tile)){
                Debug.Log("Moving " + tile + " left");
                if(dls(puzzleLeft,limit-1))
                    return true;
            }  
            Puzzle puzzleRight = current.copy();
            if (puzzleRight.moveRight(tile)){
                Debug.Log("Moving " + tile + " right");
                if(dls(puzzleRight,limit-1))
                    return true;
            }
        }
                                
        return false;

    }


}


   