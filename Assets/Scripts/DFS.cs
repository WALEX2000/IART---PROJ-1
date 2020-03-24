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

            int[] rotationAxis = current.findRotationAxis(tile);

            Puzzle puzzleUp= current.copy();
            if (puzzleUp.moveUp(tile,rotationAxis[0])){
                Debug.Log("Moving " + tile + " up");
                if(search(puzzleUp))
                    return true;

            }     
            
            Puzzle puzzleDown = current.copy();
            if (puzzleDown.moveDown(tile,rotationAxis[1])){
                Debug.Log("Moving " + tile + " down");
                if(search(puzzleDown))
                    return true;
            }    

            Puzzle puzzleLeft = current.copy();
            if (puzzleLeft.moveLeft(tile,rotationAxis[2])){
                Debug.Log("Moving " + tile + " left");
                if(search(puzzleLeft))
                    return true;
            }  
            Puzzle puzzleRight = current.copy();
            if (puzzleRight.moveRight(tile,rotationAxis[3])){
                Debug.Log("Moving " + tile + " right");
                if(search(puzzleRight))
                    return true;
            }
        }
                                
        return false;

    }

}


   