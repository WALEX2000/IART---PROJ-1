
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BFS{
    private List<Puzzle> searchQueue;

    private List<TileType> colors;
    private Puzzle puzzle;


    public BFS(Puzzle puzzle){
        colors = puzzle.puzzleColors();
        this.puzzle = puzzle.copy();
    }

    public bool search(){
        searchQueue = new List<Puzzle>();
        searchQueue.Add(puzzle);
        while(searchQueue.Count != 0){          
            if(breadthFirstSearch()){
                return true;
            }
        }
        return false;
    }

    public bool breadthFirstSearch(){


        // Puzzle current = searchQueue[searchQueue.Count-1];
        // searchQueue.RemoveAt(searchQueue.Count -1);
  
        // if(current.isComplete()){   
        //     current.displayPuzzle();
        //     return true;
        // } 

        // current.displayConsole();

        // foreach (TileType tile in colors){
            
        //     Puzzle puzzleDown = current.copy();
        //     if (puzzleDown.moveDown(tile)){
        //         searchQueue.Add(puzzleDown);                        
        //     }    
        //     Puzzle puzzleUp =current.copy();
            
        //     if (puzzleUp.moveUp(tile)){
        //         searchQueue.Add(puzzleUp);                        
        //     }     
        //     Puzzle puzzleLeft =current.copy();
        //     if (puzzleLeft.moveLeft(tile)){
        //         searchQueue.Add(puzzleLeft);                        
        //     }  
        //     Puzzle puzzleRight =current.copy();
        //     if (puzzleRight.moveRight(tile)){
        //         searchQueue.Add(puzzleRight);                        
        //     }        
        // }

        return false;

    }
}