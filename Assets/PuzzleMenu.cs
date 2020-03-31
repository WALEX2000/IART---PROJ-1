using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMenu : MonoBehaviour
{
    public GameManager gameManager;
    private string search = "";

    public Camera gameCamera;
    public Camera menuCamera;
    // Start is called before the first frame update

    public void setSearch(string searchMethod)
    {
        this.search = searchMethod;
    }
    public void choose1()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleEasy1);
        else gameManager.ManagerStarter(this.search, Example.puzzleEasy1);
    }
    public void choose2()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzle4);
        else gameManager.ManagerStarter(this.search, Example.puzzle4);
    }
    public void choose3()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleMedium);
        else gameManager.ManagerStarter(this.search, Example.puzzleMedium);
    }
    public void choose4()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzle2275);
        else gameManager.ManagerStarter(this.search, Example.puzzle2275);
    }
    public void choose5()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleDifficult);
        else gameManager.ManagerStarter(this.search, Example.puzzleDifficult);
    }
    public void choose6()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleHard);
        else gameManager.ManagerStarter(this.search, Example.puzzleHard);
    }
    public void choose7()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzle761);
        else gameManager.ManagerStarter(this.search, Example.puzzle761);
    }

    public void choose8()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzle2251);
        else gameManager.ManagerStarter(this.search, Example.puzzle2251);
    }




    public void choose9()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleExpert);
        else gameManager.ManagerStarter(this.search, Example.puzzleExpert);
    }

}
