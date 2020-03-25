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


    public List<Puzzle> search(Puzzle current){

        if(current.isComplete()){
            return new List<Puzzle>{current.copy()};
        }

        List<Puzzle> puzzleList;
        foreach (TileType tile in colors){ 

            if (current.moveDown(tile)){
                
                if((puzzleList=search(current))!=null) {
                    current.undoMoveDown(tile);
                    puzzleList.Add(current.copy());
                    return puzzleList;
                }
                
                current.undoMoveDown(tile);
            }    
            if (current.moveUp(tile)){
                
                if((puzzleList=search(current))!=null) {
                    current.undoMoveUp(tile);
                    puzzleList.Add(current.copy());
                    return puzzleList;
                }
                
                current.undoMoveUp(tile);
            }     
            if (current.moveLeft(tile)){
                
                if((puzzleList=search(current))!=null) {
                    current.undoMoveLeft(tile);
                    puzzleList.Add(current.copy());
                    return puzzleList;
                }
                
                current.undoMoveLeft(tile);
            }  
            if (current.moveRight(tile)){
                
                if((puzzleList=search(current))!=null) {
                    current.undoMoveRight(tile);
                    puzzleList.Add(current.copy());
                    return puzzleList;
                }
                
                current.undoMoveRight(tile);
            }
        }
                                
        return null;
    }

}


   