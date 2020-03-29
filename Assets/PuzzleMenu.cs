using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMenu : MonoBehaviour
{
    public GameManager gameManager;
    private string search;
    // Start is called before the first frame update

    public void setSearch(string searchMethod)
    {
        this.search = searchMethod;
    }
    public void choose1()
    {
        gameManager.ManagerStarter(this.search, Example.puzzleEasy1);
    }
    public void choose2()
    {
        gameManager.ManagerStarter(this.search, Example.puzzleMedium);
    }
    public void choose3()
    {
        gameManager.ManagerStarter(this.search, Example.puzzle4);
    }
    public void choose4()
    {
        gameManager.ManagerStarter(this.search, Example.puzzleIntermidiate);
    }
    public void choose5()
    {
        gameManager.ManagerStarter(this.search, Example.puzzleDifficult);
    }
    public void choose6()
    {
        gameManager.ManagerStarter(this.search, Example.puzzleHard);
    }
    public void choose7()
    {
        gameManager.ManagerStarter(this.search, Example.puzzleExpert);
    }

}
