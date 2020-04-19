using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Menu Manager
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Menu Pause
    public void ResumeGame(GameObject PauseMenu)
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
