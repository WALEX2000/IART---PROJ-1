using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IDDFSUndo{

    private int depth;
    private List<TileType> colors;
    private Puzzle puzzle;


    public IDDFSUndo(Puzzle puzzle,int depth){
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

            if (current.moveDown(tile)){
                Debug.Log("Moving " + tile + " down");
                if(dls(current,limit-1))
                    return true;
                Debug.Log("Undoing move " + tile + " down");
                current.undoMoveDown(tile);
            }    
            if (current.moveUp(tile)){
                Debug.Log("Moving " + tile + " up");
                if(dls(current,limit-1))
                    return true;
                Debug.Log("Undoing move " + tile + " up");
                current.undoMoveUp(tile);
            }     
            if (current.moveLeft(tile)){
                Debug.Log("Moving " + tile + " left");
                if(dls(current,limit-1))
                    return true;
                Debug.Log("Undoing move " + tile + " left");
                current.undoMoveLeft(tile);
            }  
            if (current.moveRight(tile)){
                Debug.Log("Moving " + tile + " right");
                if(dls(current,limit-1))
                    return true;
                Debug.Log("Undoing move " + tile + " right");
                current.undoMoveRight(tile);
            }
        }
                                
        return false;

    }


}


   