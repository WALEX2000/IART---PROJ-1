using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DFSUndo{
    List<TileType> colors;
    Puzzle current;



    public DFSUndo(Puzzle puzzle){
        colors = puzzle.puzzleColors();
        this.current = puzzle;
    }


    public bool search(Puzzle current){

        // if(current.isComplete()){   
        //     current.displayPuzzle();
        //     return true;
        // }

        // foreach (TileType tile in colors){ 

        //     if (current.moveDown(tile)){
        //         Debug.Log("Moving " + tile + " down");
        //         if(search(current))
        //             return true;
        //         Debug.Log("Undoing move " + tile + " down");
        //         current.undoMoveDown(tile);
        //     }    
        //     if (current.moveUp(tile)){
        //         Debug.Log("Moving " + tile + " up");
        //         if(search(current))
        //             return true;
        //         Debug.Log("Undoing move " + tile + " up");
        //         current.undoMoveUp(tile);
        //     }     
        //     if (current.moveLeft(tile)){
        //         Debug.Log("Moving " + tile + " left");
        //         if(search(current))
        //             return true;
        //         Debug.Log("Undoing move " + tile + " left");
        //         current.undoMoveLeft(tile);
        //     }  
        //     if (current.moveRight(tile)){
        //         Debug.Log("Moving " + tile + " right");
        //         if(search(current))
        //             return true;
        //         Debug.Log("Undoing move " + tile + " right");
        //         current.undoMoveRight(tile);
        //     }
        // }
                                
        return false;

    }

}


   