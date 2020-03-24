using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DFS{
    List<TileType> colors;
    Puzzle current;

    HashSet<Puzzle> visited;



    public DFS(Puzzle puzzle){
        colors = puzzle.puzzleColors();
        this.current = puzzle;
        visited = new HashSet<Puzzle>();
    }


    public bool search(Puzzle current){


        if(current.isComplete()){   
            current.displayPuzzle();
            return true;
        }

        //Acho que nao piora!! o problema e que estava a ser passado como argumento
        // if(visited.Contains(current)){
        //     return false;
        // }
        // visited.Add(current);

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


   