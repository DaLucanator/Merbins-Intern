using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassLevel : MonoBehaviour
{
    public string sceneName; // the name of the next scene to transition to (leave blank on the last level)

    public void NextScene()
    {
        if (sceneName != null) { SceneManager.LoadScene(sceneName); }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
