using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLPuzzleMenu : MonoBehaviour
{
    public GameManager gameManagerRL;
    private string algorithm = "";

    public Camera gameCameraRl;
    public Camera menuCameraRl;
    // Start is called before the first frame update

    public void setAlgorithm(string algorithm)
    {
        this.algorithm = algorithm;
    }
    public void chooseRL1()
    {
        Debug.Log("RL Puzzle 1");
        menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }
    public void chooseRL2()
    {
        Debug.Log("RL Puzzle 2");
        menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }
    public void chooseRL3()
    {
        Debug.Log("RL Puzzle 3");
        menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }
    public void chooseRL4()
    {
        Debug.Log("RL Puzzle 4");
       menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }
    public void chooseRL5()
    {
        Debug.Log("RL Puzzle 5");
        menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }
    public void chooseRL6()
    {
        Debug.Log("RL Puzzle 6");
        menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }
    public void chooseRL7()
    {
        Debug.Log("RL Puzzle 7");
        menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }

    public void chooseRL8()
    {
        Debug.Log("RL Puzzle 8");
        menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }
    public void chooseRL9()
    {
        Debug.Log("RL Puzzle 9");
        menuCameraRl.gameObject.SetActive(false);
        gameCameraRl.gameObject.SetActive(true);
        if (this.algorithm == "") gameManagerRL.RLMode(Example.puzzleEasy1);
        algorithm = "";
    }

}
