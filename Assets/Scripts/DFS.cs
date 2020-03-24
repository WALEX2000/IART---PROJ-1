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


    public List<Puzzle> search(Puzzle current){

        if(current.isComplete()){   
            return new List<Puzzle>{current.copy()};
        }

        List<Puzzle> puzzleList;
        foreach (TileType tile in colors){ 
            
            Puzzle puzzleDown = current.copy();
            if (puzzleDown.moveDown(tile)){
                if((puzzleList=search(puzzleDown))!=null) {
                    puzzleList.Add(current.copy());
                    return puzzleList;
                }
            }    

            Puzzle puzzleUp= current.copy();
            if (puzzleUp.moveUp(tile)){
                if((puzzleList=search(puzzleUp))!=null) {
                    puzzleList.Add(current.copy());
                    return puzzleList;
                }
            }     
            Puzzle puzzleLeft = current.copy();
            if (puzzleLeft.moveLeft(tile)){
                if((puzzleList=search(puzzleLeft))!=null) {
                    puzzleList.Add(current.copy());
                    return puzzleList;
                }
            }  
            Puzzle puzzleRight = current.copy();
            if (puzzleRight.moveRight(tile)){
                if((puzzleList=search(puzzleRight))!=null) {
                    puzzleList.Add(current.copy());
                    return puzzleList;
                }
            }
        }
                                
        return null;
    }

}


   