using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");

        Application.Quit();
    }

    public void ReLoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReLoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

}
