using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiGameHUD : MonoBehaviour
{
    public void RestartBtnClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuBtnClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }
}