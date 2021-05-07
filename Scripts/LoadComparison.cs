using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadComparison : MonoBehaviour
{
      public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Exiting...");
    }

    public void launchAStar(){
        SceneManager.LoadScene("AStar");
    }

    public void launchDijkstra(){
        SceneManager.LoadScene("Dijkstras");
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("NewMainMenu");
    }

}
