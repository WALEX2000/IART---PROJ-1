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
        search = "";
    }
    public void choose2()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzle4);
        else gameManager.ManagerStarter(this.search, Example.puzzle4);
        search = "";
    }
    public void choose3()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleMedium);
        else gameManager.ManagerStarter(this.search, Example.puzzleMedium);
        search = "";
    }
    public void choose4()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzle2275);
        else gameManager.ManagerStarter(this.search, Example.puzzle2275);
        search = "";
    }
    public void choose5()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleDifficult);
        else gameManager.ManagerStarter(this.search, Example.puzzleDifficult);
        search = "";
    }
    public void choose6()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleHard);
        else gameManager.ManagerStarter(this.search, Example.puzzleHard);
        search = "";
    }
    public void choose7()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzle761);
        else gameManager.ManagerStarter(this.search, Example.puzzle761);
        search = "";
    }

    public void choose8()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzle2251);
        else gameManager.ManagerStarter(this.search, Example.puzzle2251);
        search = "";
    }
    public void choose9()
    {

        //TEST
        Generator generator = new Generator();
        int size = 12;
        TileType[][] matrix = new TileType[size][];
        matrix = generator.generatePuzzle(size,3,6);
        //generator.unfold(matrix);
        generator.displayConsole(matrix);


        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(matrix);
        else gameManager.ManagerStarter(this.search, matrix);
        search = "";


        /*menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        if (this.search == "") gameManager.HumanMode(Example.puzzleExpert);
        else gameManager.ManagerStarter(this.search, Example.puzzleExpert);
        search = "";*/  
    }

}
