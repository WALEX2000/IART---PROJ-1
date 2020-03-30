using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHint : MonoBehaviour
{
    // Start is called before the first frame update
    public Puzzle puzzle;

    public void getHint()
    {
        Node solution = puzzle.search("DFSUndo");
        List<Puzzle> steps = solution.getPath();
        steps[1].displayPuzzle();
    }

}
