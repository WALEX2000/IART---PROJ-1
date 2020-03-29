using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMenu : MonoBehaviour
{
    public GameManager gameManager;
    public Camera gameCamera;
    public Camera menuCamera;
    private string search;
    // Start is called before the first frame update

    public void setSearch(string searchMethod)
    {
        this.search = searchMethod;
    }
    public void choose1()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
        gameManager.ManagerStarter(this.search);
    }

}
