using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetHint : MonoBehaviour
{
    // Start is called before the first frame update
    public Puzzle puzzle;

    public void Wait(float seconds, Action action)
    {
        StartCoroutine(_wait(seconds, action));
    }
    IEnumerator _wait(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
    }

    //Displays the recomended next step for one second
    public void getHint()
    {
        Node solution = puzzle.search("AStar");
        if (solution == null)
        {
            Debug.Log("Impossible to solve!");
            return;
        }
        List<Node> steps = solution.getPath();
        steps[1].puzzle.displayPuzzle();
        Wait(1, () =>
        {
            steps[1].puzzle.hidePuzzle();
        });


    }


}
