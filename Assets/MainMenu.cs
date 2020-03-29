using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;
    public PuzzleMenu puzzleMenu;
    public Camera gameCamera;
    public Camera menuCamera;
    // Start is called before the first frame update

    public void Start()
    {
        gameCamera.gameObject.SetActive(false);
    }
    public void DFS()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        gameManager.ManagerStarter("DFSUndo");
    }

    public void BFS()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        gameManager.ManagerStarter("BFS");
    }
    public void IDDFS()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        // Camera.main = gameCamera;
        gameManager.ManagerStarter("IDDFSUndo");
    }

    public void SimpleGreedy()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        // Camera.main = gameCamera;
        gameManager.ManagerStarter("SimpleGreedy");
    }

    public void AStar()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        // Camera.main = gameCamera;
        gameManager.ManagerStarter("AStar");
    }

    public void UniformCost()
    {
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        // Camera.main = gameCamera;
        gameManager.ManagerStarter("UniformCost");
    }
}
