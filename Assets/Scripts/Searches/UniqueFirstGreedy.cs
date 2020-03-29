using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Move : IComparable<Move>
{
    public int score;
    public List<Tuple<int, int>> positions;
    public TileType tile;
    public Move(List<Tuple<int, int>> positions, TileType tile)
    {
        this.positions = positions;
        this.score = 0;
        this.tile = tile;
    }
    public void setScore(int newScore) { this.score = newScore; }
    public void addOne() { score++; }

    public int CompareTo(Move other)
    {
        if (this.score > other.score) return 1;
        else if (this.score < other.score) return -1;
        else return 0;
    }
}

public class UniqueFirstGreedy
{
    private Node resultNode;
    private List<Move>[][] stubMatrix;
    private List<TileType> colors;
    private List<Puzzle> solution = new List<Puzzle>();

    private Boolean size;
    public Node solve(Puzzle puzzle, Boolean size)
    {
        this.size = size;
        colors = puzzle.puzzleColors();
        Node node = new Node(puzzle, null, 0);
        findSolution(node);
        return resultNode;
    }

    private bool findSolution(Node puzzleNode)
    {
        Puzzle puzzle = puzzleNode.puzzle;
        //Check if the puzzle is complete
        if (puzzle.isComplete())
        {
            resultNode = puzzleNode;
            Debug.Log("Search Completed successfully");
            return true;
        }

        //initialize stub Matrix with an empty matrix
        stubMatrix = new List<Move>[puzzle.PuzzleMatrix.Length][];
        for (int i = 0; i < stubMatrix.Length; i++)
        {
            stubMatrix[i] = new List<Move>[puzzle.PuzzleMatrix[i].Length];
            for (int j = 0; j < stubMatrix[i].Length; j++)
            {
                stubMatrix[i][j] = new List<Move>();
            }
        }

        List<Move> allMoves = new List<Move>();
        foreach (TileType tile in colors)
        {
            List<Tuple<int, int>> moveDownList = puzzle.getMoveDownList(tile);
            if (moveDownList != null)
            {
                Move move = new Move(moveDownList, tile);
                addMoveToStub(move);
                allMoves.Add(move);
            }

            List<Tuple<int, int>> moveUpList = puzzle.getMoveUpList(tile);
            if (moveUpList != null)
            {
                Move move = new Move(moveUpList, tile);
                addMoveToStub(move);
                allMoves.Add(move);
            }

            List<Tuple<int, int>> moveLeftList = puzzle.getMoveLeftList(tile);
            if (moveLeftList != null)
            {
                Move move = new Move(moveLeftList, tile);
                addMoveToStub(move);
                allMoves.Add(move);
            }

            List<Tuple<int, int>> moveRightList = puzzle.getMoveRightList(tile);
            if (moveRightList != null)
            {
                Move move = new Move(moveRightList, tile);
                addMoveToStub(move);
                allMoves.Add(move);
            }
        }
        //order moves in a priorityqueue
        PriorityQueue<Move> priorityQueue = new PriorityQueue<Move>();
        foreach (Move move in allMoves) {
            if(this.size) move.score = move.score/move.positions.Count;
            priorityQueue.Enqueue(move);
        }

        //get all the ones that are tied at the top and resolve the ties
        Tuple<List<Move>, List<Move>> tuple = priorityQueue.splitFrontItems();
        List<Move> bestMoves = tuple.Item1;
        List<Move> lastMoves = tuple.Item2;

        if(bestMoves.Count > 1) bestMoves = resolveTies(bestMoves, puzzle);

        //Now that we have the list ordered without ties go through it and recall findSolution with the resultant board
        foreach (Move move in bestMoves)
        {
            Puzzle newPuzzle = puzzle.copy();
            newPuzzle.executeMove(move.positions, move.tile);
            Node node = new Node(newPuzzle, puzzleNode, 0);
            if (findSolution(node)) return true;            
        }
        foreach (Move move in lastMoves)
        {
            Puzzle newPuzzle = puzzle.copy();
            newPuzzle.executeMove(move.positions, move.tile);
            Node node = new Node(newPuzzle, puzzleNode, 0);
            if (findSolution(node)) return true;            
        }
        return false;
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
                newMoves.Add(newMove);
            }

            List<Tuple<int, int>> moveUpList = copyPuzzle.getMoveUpList(move.tile);
            if (moveUpList != null)
            {
                Move newMove = new Move(moveUpList, move.tile);
                checkMoveOnStub(newMove);
                newMove.positions.AddRange(move.positions); //Adding prior positions to new move
                newMoves.Add(newMove);
            }

            List<Tuple<int, int>> moveLeftList = copyPuzzle.getMoveLeftList(move.tile);
            if (moveLeftList != null)
            {
                Move newMove = new Move(moveLeftList, move.tile);
                checkMoveOnStub(newMove);
                newMove.positions.AddRange(move.positions); //Adding prior positions to new move
                newMoves.Add(newMove);
            }

            List<Tuple<int, int>> moveRightList = copyPuzzle.getMoveRightList(move.tile);
            if (moveRightList != null)
            {
                Move newMove = new Move(moveRightList, move.tile);
                checkMoveOnStub(newMove);
                newMove.positions.AddRange(move.positions); //Adding prior positions to new move
                newMoves.Add(newMove);
            }
        }
        PriorityQueue<Move> priorityQueue = new PriorityQueue<Move>();
        foreach (Move newMove in newMoves) {
            if(this.size) newMove.score = newMove.score/newMove.positions.Count;
            priorityQueue.Enqueue(newMove);
        }
        Tuple<List<Move>,List<Move>> tuple = priorityQueue.splitFrontItems();
        List<Move> newBestMoves = tuple.Item1;
        List<Move> lastMoves = tuple.Item2;        
        if (newBestMoves.Count > 1) {
            List<Move> newM = resolveTies(newBestMoves, puzzle);
            if(newM[0] != newBestMoves[0]) newM.AddRange(newBestMoves);
            newM.AddRange(lastMoves);
            return newM;
        }            
        else {
            if(newMoves.Count == 0) newBestMoves = bestMoves;
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


