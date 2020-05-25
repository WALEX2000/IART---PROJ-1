using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using System;

public enum MoveDirection { Up, Left, Right, Down }

public class PuzzleAgent : Agent
{
    public TrainingManager manager;
    public Transform puzzleTransform; //Used to tell the manager where to display the puzzle (merely graphical)
    private Puzzle puzzle;
    public override void OnEpisodeBegin()
    { //Sets up the Training Area at the beggining of each Episode
        //Get a new Puzzle
        puzzle = manager.generatePuzzle();
        if(puzzle == null) {
            Debug.LogError("The Training Manager has an empty puzzle dataBase");
            return;
        }

        //Display the Puzzle
        manager.displayPuzzle(puzzle, puzzleTransform);
    }

    public override void CollectObservations(VectorSensor sensor)
    { //Gives the agent information regarding the puzzleState (Before each action he takes)
        Debug.Log("Collecting Observations");
        for(int i = 0; i < puzzle.PuzzleMatrix.Length; i++) {
            float[] result = Array.ConvertAll(puzzle.PuzzleMatrix[i], value => (float) value);
            sensor.AddObservation(result);
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    { //This method updates the puzzle corresponding to the received actions (And rewards in case of success)
        
        Debug.Log("Action Array: " + vectorAction);
        // Actions, size = 2 (The first number is the color to move, and the second the direction)
        TileType movedTile = (TileType) Mathf.FloorToInt(vectorAction[0]); // will correspond to vectorAction[0]; (can only be one of the TileTypes present in the current puzzle)
        MoveDirection moveDirection = (MoveDirection) Mathf.FloorToInt(vectorAction[1]);// correspond to vectorAction[1]; (can only go from 0 to 3)

        // Change puzzle according to the actions received
        switch(moveDirection) {
            case MoveDirection.Up:
                if(!puzzle.moveUp(movedTile)) SetReward(-.1f);
                break;
            case MoveDirection.Down:
                if(!puzzle.moveDown(movedTile)) SetReward(-.1f);
                break;
            case MoveDirection.Left:
                if(!puzzle.moveLeft(movedTile)) SetReward(-.1f);
                break;
            case MoveDirection.Right:
                if(!puzzle.moveRight(movedTile)) SetReward(-.1f);
                break;
        }

        //Display the new puzzle State
        manager.displayPuzzle(puzzle, puzzleTransform);

        //If puzzle was completed with success end and give a reward
        if(puzzle.isComplete()) {
            SetReward(1.0f);
            EndEpisode();
        }
        //Else if there are no more moves that can be executed in the puzzle: EndEpisode(); (With no Reward)
    }

    public override void CollectDiscreteActionMasks(DiscreteActionMasker actionMasker){
        actionMasker.SetMask(0, puzzle.getListOfValidTypes().ToArray()); //Mask for tile types
        actionMasker.SetMask(1, new int[4] {0,1,2,3});
    }
}
