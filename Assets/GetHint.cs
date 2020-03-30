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


    public void getHint()
    {
        Node solution = puzzle.search("AStar");
        List<Puzzle> steps = solution.getPath();
        steps[1].displayPuzzle();
        Wait(1, () =>
        {
            steps[1].hidePuzzle();
        });


    }


}
