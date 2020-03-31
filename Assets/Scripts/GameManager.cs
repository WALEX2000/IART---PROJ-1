using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
enum playerType { Bot, Player };

public class GameManager : MonoBehaviour
{
    public Puzzle currentPuzzle;
    private Puzzle firstPuzzle;
    private playerType currentPlayer;
    public GameObject tilePrefab;
    public GameObject hintButton;
    public GameObject cursorTrail;

    public GameObject canvas;    

    public Camera gameCamera;

    private Boolean trail = false;

    private Boolean AIrunning = false;

    private List<GameObject> tileGroups = new List<GameObject>();

    void Update() {        
        Vector3 pos = gameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.2f));
        if(trail) cursorTrail.transform.position = new Vector3(pos.x, 2f, pos.z);     
    }

    public bool humanBusy = false;
    //Used to run all the tests when needed
    public void Start()
    {
        cursorTrail.SetActive(false);
        canvas.SetActive(false);
        //Test test = new Test(tilePrefab);
        //test.runTests(5, "Results/All.txt");
    }

    public void ManagerStarter(string searchOption, TileType[][] puzzleLevel)
    {
        AIrunning = true;
        canvas.SetActive(true);
        hintButton.SetActive(false);
        currentPuzzle = new Puzzle(copyMatrix(puzzleLevel), tilePrefab);

        firstPuzzle = new Puzzle(puzzleLevel, tilePrefab);

        currentPuzzle.displayPuzzle();

        var watch = System.Diagnostics.Stopwatch.StartNew();

        Debug.Log(searchOption);
        Node solution = currentPuzzle.search(searchOption);

        watch.Stop();
        Debug.Log("Time taken: " + watch.ElapsedMilliseconds / 1000.0);

        if (solution == null)
        {
            Debug.LogError("Algorithm failed to solve puzzle!!");
            return;
        }

        List<Node> steps = solution.getPath();

        Debug.Log("Steps taken: " + steps.Count);

        StartCoroutine(DisplayPuzzleStates(steps, 0.5f));
    }

    public void hidePuzzle()
    {
        currentPuzzle.hidePuzzle();
    }
    public void backToOriginal()
    {
        currentPuzzle = firstPuzzle;
        Cursor.visible = true;
        trail = false;
        cursorTrail.SetActive(false);
        AIrunning = false;
        DeleteTileGroups(tileGroups);
    }

    //Given the puzzle displays it so the player can solve the puzzle
    public void HumanMode(TileType[][] puzzleLevel)
    {
        hintButton.SetActive(true);
        trail = true;
        cursorTrail.SetActive(true);
        canvas.SetActive(true);
        Cursor.visible = false;
        currentPuzzle = new Puzzle(copyMatrix(puzzleLevel), tilePrefab);
        firstPuzzle = currentPuzzle.copy();
        currentPuzzle.gameManager = this;
        currentPuzzle.displayPuzzle();
        hintButton.GetComponent<GetHint>().puzzle = currentPuzzle;
    }

    private List<Puzzle> puzzleStates = new List<Puzzle>();
    public void DisplayState(Puzzle puzzle)
    {
        puzzleStates.Add(puzzle);
    }

    //Displays the steps taken to reach the solution
    private IEnumerator DisplayPuzzleStates(List<Node> steps, float time)
    {        
        //Debug.Log(puzzleStates.Count);
        for (int i = 0; i < steps.Count; i++)
        {
            if (i != 0)
            {
                if(AIrunning == false) break;
                GameObject tileGroup = steps[i - 1].puzzle.displayTilesOfType(steps[i].movedTile); //Display the tiles that moved from the last puzzle to the current                
                Vector3 target = getTarget(tileGroup, steps[i].moveType);
                Vector3 axis = Vector3.forward;  //Forwards for down or up, Right for left or right   
                int direction = 1; //positive for right and up  
                if (steps[i].moveType == MoveType.Right || steps[i].moveType == MoveType.Left) axis = Vector3.right;
                if (steps[i].moveType == MoveType.Down || steps[i].moveType == MoveType.Left) direction = -1;
                for (int j = 0; j < 180 / 5; j++)
                {
                    if(AIrunning == false) break;                    
                    tileGroup.transform.RotateAround(target, axis, 5 * direction);
                    yield return new WaitForSeconds(0.0001f);
                }
                tileGroups.Add(tileGroup);
            }
            if(AIrunning == false) break;          
            yield return new WaitForSeconds(time);
        }
    }

    private void DeleteTileGroups(List<GameObject> tileGroups) {
        foreach(GameObject tileGroup in tileGroups) {
            Destroy(tileGroup);
        }
    }

    private Vector3 getTarget(GameObject tileGroup, MoveType move)
    {
        //For down we need highest X / For up lowest X
        //For Left we need lowest Z / For right highest Z
        Vector3 target = new Vector3(0.0f, -1.1f, 0.0f); //hopefully this is ok
        foreach (Transform tile in tileGroup.transform)
        {
            switch (move)
            {
                case MoveType.Down:
                    if (tile.position.x > target.x || target.y == -1.1f)
                    {
                        target = tile.position;
                        target.x += 0.5f;
                    }
                    break;
                case MoveType.Up:
                    if (tile.position.x < target.x || target.y == -1.1f)
                    {
                        target = tile.position;
                        target.x -= 0.5f;
                    }
                    break;
                case MoveType.Left:
                    if (tile.position.z < target.z || target.y == -1.1f)
                    {
                        target = tile.position;
                        target.z -= 0.5f;
                    }
                    break;
                case MoveType.Right:
                    if (tile.position.z > target.z || target.y == -1.1f)
                    {
                        target = tile.position;
                        target.z += 0.5f;
                    }
                    break;
            }
        }
        return target;
    }
    //Returns a copy of the given matrix
    public TileType[][] copyMatrix(TileType[][] matrix)
    {
        TileType[][] copy = new TileType[matrix.Length][];
        for (int i = 0; i < matrix.Length; i++)
        {
            copy[i] = new TileType[matrix[i].Length];
            Array.Copy(matrix[i], copy[i], matrix[i].Length);
        }
        return copy;
    }
}
