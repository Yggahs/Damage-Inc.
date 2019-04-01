using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject PauseMenu, Player;
   

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        Player.GetComponent<CharacterController2D>().OnRespawn();
        Time.timeScale = 1;
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
