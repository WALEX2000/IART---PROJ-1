using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

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
        //sensor.AddObservation(puzzle.PuzzleMatrix); //TODO figure out a way to pass the puzzleMatrix (since TileType[][] is not and accepted input)
    }

    public override void OnActionReceived(float[] vectorAction)
    { //This method updates the puzzle corresponding to the received actions (And rewards in case of success)
        
        // Actions, size = 2 (The first number is the color to move, and the second the direction)
        TileType movedTile = 0; // will correspond to vectorAction[0]; (can only be one of the TileTypes present in the current puzzle)
        MoveDirection moveDirection = 0;// correspond to vectorAction[1]; (can only go from 0 to 3)

        // Change puzzle according to the actions received
        switch(moveDirection) { //We will probably want to check if the move was executed and give a negative reward if it wasn't
            case MoveDirection.Up:
                puzzle.moveUp(movedTile);
                break;
            case MoveDirection.Down:
                puzzle.moveDown(movedTile);
                break;
            case MoveDirection.Left:
                puzzle.moveLeft(movedTile);
                break;
            case MoveDirection.Right:
                puzzle.moveRight(movedTile);
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
}
