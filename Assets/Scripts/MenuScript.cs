using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject PauseMenu;

    public void ExitGame()
    {
        Debug.Log("kek");
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
