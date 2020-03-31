using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//Objective: Do the more unique solutions first
//How
//For a puzzle, expand all colors in four directions
//See what are the moves that result in more unique solutions
//Do those first
public class UniformCost
{

    private List<TileType> colors;
    private PriorityQueue<Node> priorityQueue;
    private HashSet<TileType[][]> visited;
    private List<Move>[][] stubMatrix;
    private int numNodes = 0;


    public Node search(Puzzle puzzle)
    {
        colors = puzzle.puzzleColors();
        priorityQueue = new PriorityQueue<Node>();
        visited = new HashSet<TileType[][]>();

        priorityQueue.Enqueue(new Node(puzzle, null, 0));
        return uniformCost();
    }

    //Preenche primeiro os maiores
    public static int calculatePuzzleScore(Puzzle current)
    {
        int score = 0;
        for (int i = 0; i < current.PuzzleMatrix.Length; i++)
        {
            for (int j = 0; j < current.PuzzleMatrix[0].Length; j++)
            {
                if (current.PuzzleMatrix[i][j] != TileType.Null && current.PuzzleMatrix[i][j] != TileType.Empty) score += 1;
            }
        }
        return score;
    }

    private Node uniformCost()
    {
        while (priorityQueue.Count() != 0)
        {
            numNodes++;
            Node current = priorityQueue.Dequeue();

            if (current.puzzle.isComplete())
            {
                Debug.Log("Solved");
                Debug.Log(numNodes);
                return current;
            }

            stubMatrix = new List<Move>[current.puzzle.PuzzleMatrix.Length][];
            for (int i = 0; i < stubMatrix.Length; i++)
            {
                stubMatrix[i] = new List<Move>[current.puzzle.PuzzleMatrix[i].Length];
                for (int j = 0; j < stubMatrix[i].Length; j++)
                {
                    stubMatrix[i][j] = new List<Move>();
                }
            }

            List<Move> allMoves = new List<Move>();
            foreach (TileType tile in colors)
            {
                List<Tuple<int, int>> moveDownList = current.puzzle.getMoveDownList(tile);
                if (moveDownList != null)
                {
                    Move move = new Move(moveDownList, tile);
                    move.moveType.Add(MoveType.Down);
                    addMoveToStub(move);
                    allMoves.Add(move);                                
                }

                List<Tuple<int, int>> moveUpList = current.puzzle.getMoveUpList(tile);
                if (moveUpList != null)
                {
                    Move move = new Move(moveUpList, tile);
                    move.moveType.Add(MoveType.Up);
                    addMoveToStub(move);
                    allMoves.Add(move);
                }

                List<Tuple<int, int>> moveLeftList = current.puzzle.getMoveLeftList(tile);
                if (moveLeftList != null)
                {
                    Move move = new Move(moveLeftList, tile);
                    move.moveType.Add(MoveType.Left);
                    addMoveToStub(move);
                    allMoves.Add(move);
                }

                List<Tuple<int, int>> moveRightList = current.puzzle.getMoveRightList(tile);
                if (moveRightList != null)
                {
                    Move move = new Move(moveRightList, tile);
                    move.moveType.Add(MoveType.Right);
                    addMoveToStub(move);
                    allMoves.Add(move);
                }
            }
            //order moves in a priorityqueue
            PriorityQueue<Move> movePriorityQueue = new PriorityQueue<Move>();
            foreach (Move move in allMoves)
            {
                movePriorityQueue.Enqueue(move);
            }

            //get all the ones that are tied at the top and resolve the ties
            Tuple<List<Move>, List<Move>> tuple = movePriorityQueue.splitFrontItems();
            List<Move> bestMoves = tuple.Item1;
            List<Move> lastMoves = tuple.Item2;

            if (bestMoves.Count > 1) bestMoves = resolveTies(bestMoves, current.puzzle);

            //Now that we have the list ordered without ties go through it and recall findSolution with the resultant board
            foreach (Move move in bestMoves)
            {
                Node father = current;
                Node last = null;
                for(int i = move.steps.Count - 1; i >= 0; i--) {
                    Puzzle newPuzzle = father.puzzle.copy();
                    newPuzzle.executeMove(move.steps[i], move.tile);  
                    Node next = new Node(newPuzzle, father, current.value + move.score);
                    next.movedTile = move.tile;
                    next.moveType = move.moveType[i];
                    father = next;
                    last = next;           
                }
                priorityQueue.Enqueue(last);
            }
            foreach (Move move in lastMoves)
            {
                Node father = current;
                Node last = null;
                for(int i = move.steps.Count - 1; i >= 0; i--) {
                    Puzzle newPuzzle = father.puzzle.copy();
                    newPuzzle.executeMove(move.steps[i], move.tile);  
                    Node next = new Node(newPuzzle, father, current.value + move.score);
                    next.movedTile = move.tile;
                    next.moveType = move.moveType[i];
                    father = next;
                    last = next;           
                }
                priorityQueue.Enqueue(last);
            }
        }
        return null;
    }
    private List<Move> resolveTies(List<Move> bestMoves, Puzzle puzzle)
    {
        List<Move> newMoves = new List<Move>();
        foreach (Move move in bestMoves)
        {
            Puzzle copyPuzzle = puzzle.copy();
            copyPuzzle.executeMove(move.positions, move.tile);

            List<Tuple<int, int>> moveDownList = copyPuzzle.getMoveDownList(move.tile);
            if (moveDownList != null)
            {
                Move newMove = new Move(moveDownList, move.tile);
                checkMoveOnStub(newMove);                
                newMove.positions.AddRange(move.positions); //Adding prior positions to new move
                newMove.steps.AddRange(move.steps);
                newMove.moveType.Add(MoveType.Down);
                newMove.moveType.AddRange(move.moveType);
                newMoves.Add(newMove);
            }

            List<Tuple<int, int>> moveUpList = copyPuzzle.getMoveUpList(move.tile);
            if (moveUpList != null)
            {
                Move newMove = new Move(moveUpList, move.tile);
                checkMoveOnStub(newMove);
                newMove.positions.AddRange(move.positions); //Adding prior positions to new move
                newMove.steps.AddRange(move.steps);
                newMove.moveType.Add(MoveType.Up);
                newMove.moveType.AddRange(move.moveType);
                newMoves.Add(newMove);
            }

            List<Tuple<int, int>> moveLeftList = copyPuzzle.getMoveLeftList(move.tile);
            if (moveLeftList != null)
            {
                Move newMove = new Move(moveLeftList, move.tile);
                checkMoveOnStub(newMove);
                newMove.positions.AddRange(move.positions); //Adding prior positions to new move
                newMove.steps.AddRange(move.steps);
                newMove.moveType.Add(MoveType.Left);
                newMove.moveType.AddRange(move.moveType);
                newMoves.Add(newMove);
            }

            List<Tuple<int, int>> moveRightList = copyPuzzle.getMoveRightList(move.tile);
            if (moveRightList != null)
            {
                Move newMove = new Move(moveRightList, move.tile);
                checkMoveOnStub(newMove);
                newMove.positions.AddRange(move.positions); //Adding prior positions to new move
                newMove.steps.AddRange(move.steps);
                newMove.moveType.Add(MoveType.Right);
                newMove.moveType.AddRange(move.moveType);
                newMoves.Add(newMove);
            }
        }
        PriorityQueue<Move> movePriorityQueue = new PriorityQueue<Move>();
        foreach (Move newMove in newMoves)
        {
            movePriorityQueue.Enqueue(newMove);
        }
        Tuple<List<Move>, List<Move>> tuple = movePriorityQueue.splitFrontItems();
        List<Move> newBestMoves = tuple.Item1;
        List<Move> lastMoves = tuple.Item2;
        if (newBestMoves.Count > 1)
        {
            List<Move> newM = resolveTies(newBestMoves, puzzle);
            newM.AddRange(newBestMoves);
            newM.AddRange(lastMoves);
            return newM;
        }
        else
        {
            if (newMoves.Count == 0) newBestMoves = bestMoves;
            newBestMoves.AddRange(lastMoves);
            return newBestMoves;
        }
    }

    private void checkMoveOnStub(Move move)
    {
        foreach (Tuple<int, int> coords in move.positions)
        {
            List<Move> overlappingMoves = stubMatrix[coords.Item1][coords.Item2];
            move.score += overlappingMoves.Count;
        }
    }

    private void addMoveToStub(Move move)
    {
        foreach (Tuple<int, int> coords in move.positions)
        {
            List<Move> overlappingMoves = stubMatrix[coords.Item1][coords.Item2];

            for (int i = 0; i < overlappingMoves.Count; i++)
            {
                Move moveFound = overlappingMoves[i];
                moveFound.addOne();
                move.addOne();
            }
            overlappingMoves.Add(move);
        }
    }
}


