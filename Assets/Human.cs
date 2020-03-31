using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private Vector3 mouseDownPos;
    private Vector3 lastMouseCoordinate = Vector3.zero;
    bool moving = false;
    public Puzzle puzzle;
    public TileType tile;
    private Vector3 v3Pos;
    private int threshold = 9;
    public GameObject hintButton;
    public GameManager gameManager;

    void OnMouseDown()
    {
        moving = true;
        v3Pos = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        // hintButton.GetComponent<GetHint>().puzzle = puzzle;
        if (!moving) return;
        
        Puzzle newPuzzle = puzzle.copy();
        Puzzle oldPuzzle = puzzle.copy();
        MoveType moveType = MoveType.NULL;        

        var v3 = Input.mousePosition - v3Pos;
        v3.Normalize();
        var f = Vector3.Dot(v3, Vector3.up);
        if (Vector3.Distance(v3Pos, Input.mousePosition) < threshold) return;

        if (f >= 0.5) {
            if(newPuzzle.moveUp(tile)) moveType = MoveType.Up;
        }
        else if (f <= -0.5) {
            if(newPuzzle.moveDown(tile)) moveType = MoveType.Down;
        }
        else
        {
            f = Vector3.Dot(v3, Vector3.right);
            if (f >= 0.5) { 
                if(newPuzzle.moveRight(tile)) moveType = MoveType.Right;
            }
            else if(newPuzzle.moveLeft(tile)) moveType = MoveType.Left;
        }
        
        if(moveType != MoveType.NULL) StartCoroutine(animateMove(oldPuzzle, moveType, tile, newPuzzle));                

        v3Pos = Input.mousePosition;

        if (puzzle.isComplete())
        {
            Debug.Log("Puzzle Completed successfuly");
        }

        moving = false;
    }

    private IEnumerator animateMove(Puzzle oldPuzzle, MoveType moveType, TileType movedTile, Puzzle newPuzzle) {
        GameObject tileGroup = oldPuzzle.displayTilesOfType(movedTile); //Display the tiles that moved from the last puzzle to the current                
        Vector3 target = getTarget(tileGroup, moveType, movedTile);                
        Vector3 axis = Vector3.forward;  //Forwards for down or up, Right for left or right   
        int direction = 1; //positive for right and up  
        if(moveType == MoveType.Right || moveType == MoveType.Left) axis = Vector3.right;
        if(moveType == MoveType.Down || moveType == MoveType.Left) direction = -1;
        for(int j = 0; j < 180/5; j++) {            
            tileGroup.transform.RotateAround(target,axis, 5*direction);       
            yield return new WaitForSeconds(0.0001f);
        }
        newPuzzle.displayPuzzle(); 
        puzzle.hidePuzzle();
        puzzle = newPuzzle;
        if(gameManager == null) Debug.LogError("WHAAT?");
        gameManager.currentPuzzle = puzzle;     
        Destroy(tileGroup);
    }

    private Vector3 getTarget(GameObject tileGroup, MoveType move, TileType movedTile) {
        //For down we need highest X / For up lowest X
        //For Left we need lowest Z / For right highest Z
        Vector3 target = new Vector3(0.0f, -1.1f, 0.0f); //hopefully this is ok
        foreach(Transform tile in tileGroup.transform) {
            tile.GetComponent<Human>().puzzle = puzzle;
            tile.GetComponent<Human>().tile = movedTile;    
            switch(move) {
                case MoveType.Down:
                    if(tile.position.x > target.x || target.y == -1.1f) {
                        target = tile.position;
                        target.x += 0.5f;
                    }
                    break;
                case MoveType.Up:
                    if(tile.position.x < target.x || target.y == -1.1f) {
                        target = tile.position;
                        target.x -= 0.5f;
                    }
                    break;
                case MoveType.Left:
                    if(tile.position.z < target.z || target.y == -1.1f) {
                        target = tile.position;
                        target.z -= 0.5f;
                    }
                    break;
                case MoveType.Right:
                    if(tile.position.z > target.z || target.y == -1.1f) {
                        target = tile.position;
                        target.z += 0.5f;
                    }
                    break;
            }
        }        
        return target;
    }
    void onMouseUp()
    {
        moving = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
