using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using System;

public enum MoveDirection { Up, Left, Right, Down }

public class PuzzleAgent : Agent
{
    public PuzzleManager manager;
    public Transform puzzleTransform; //Used to tell the manager where to display the puzzle (merely graphical)
    private Puzzle puzzle;
    public Boolean testing = false;
    public override void OnEpisodeBegin()
    { //Sets up the Training Area at the beggining of each Episode
        //Debug.Log("Started new episode");
        //Get a new Puzzle
        puzzle = manager.generatePuzzle();
        if(puzzle == null) {
            Debug.LogError("The Training Manager has an empty puzzle dataBase");
            return;
        }
        //Display the Puzzle
        //manager.displayPuzzle(puzzle, puzzleTransform);
        
        //puzzle.displayConsole();
    }

    public override void CollectObservations(VectorSensor sensor)
    { //Gives the agent information regarding the puzzleState (Before each action he takes)
        for(int i = 0; i < puzzle.PuzzleMatrix.Length; i++) {
            float[] result = Array.ConvertAll(puzzle.PuzzleMatrix[i], value => (float) value);
            //Debug.Log(result);
            sensor.AddObservation(result);
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    { //This method updates the puzzle corresponding to the received actions (And rewards in case of success)
        
        //Debug.Log("Tile to move: " + vectorAction[0]);
        //Debug.Log("Movement Direction: " + vectorAction[1]);
        // Actions, size = 2 (The first number is the color to move, and the second the direction)
        TileType movedTile = (TileType) Mathf.FloorToInt(vectorAction[0]); // Tile to move
        MoveDirection moveDirection = (MoveDirection) Mathf.FloorToInt(vectorAction[1]); // direction to move

        // Change puzzle according to the actions received
        switch(moveDirection) {
            case MoveDirection.Up:
                if(!puzzle.moveUp(movedTile)) {
                    SetReward(-0.05f);
                    return;
                }
                break;
            case MoveDirection.Down:
                if(!puzzle.moveDown(movedTile)) {
                    SetReward(-0.05f);
                    return;
                }
                break;
            case MoveDirection.Left:
                if(!puzzle.moveLeft(movedTile)) {
                    SetReward(-0.05f);
                    return;
                }
                break;
            case MoveDirection.Right:
                if(!puzzle.moveRight(movedTile)) {
                    SetReward(-0.05f);
                    return;
                }
                break;
            default:
                Debug.Log("Unknown direction");
                return;
        }

        Node next = new Node(puzzle.copy(), null, 0);
        next.movedTile = movedTile;
        switch(moveDirection) {
            case MoveDirection.Down:
                next.moveType = MoveType.Down;
                break;
            case MoveDirection.Up:
                next.moveType = MoveType.Up;
                break;
            case MoveDirection.Left:
                next.moveType = MoveType.Left;
                break;
            case MoveDirection.Right:
                next.moveType = MoveType.Right;
                break;
            default:
                break;
        }
        manager.addStep(next);

        SetReward(0.1f);

        //If puzzle was completed with success end and give a reward
        if(puzzle.isComplete()) {
            manager.showResult();
            SetReward(1);
            Destroy(GetComponent<DecisionRequester>());
        }
        else if(puzzle.hasFailed()) {
            manager.resetSteps();
            SetReward(-0.8f);
        }
        //Else if there are no more moves that can be executed in the puzzle: EndEpisode(); (With no Reward)
    }

    public override void CollectDiscreteActionMasks(DiscreteActionMasker actionMasker){
        List<int> allItems = new List<int>(new int[] {0,1,2,3,4,5,6,7,8,9});
        allItems.RemoveAll(item => puzzle.getListOfValidTypes().Contains(item));
        actionMasker.SetMask(0, allItems); //Mask for tile types
        //actionMasker.SetMask(1, new int[4] {0,1,2,3}); //Unecessary Probably

        /*
        for(int i = 0; i < puzzle.getListOfValidTypes().ToArray().Length; i++) {
            Debug.Log("Mask: " + puzzle.getListOfValidTypes().ToArray()[i]);
        }
        */
    }
}
