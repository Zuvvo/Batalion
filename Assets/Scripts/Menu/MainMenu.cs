using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartBtnClick()
    {
        SceneManager.LoadScene("MissionSelect");
    }

    public void OptionsBtnClick()
    {
        Debug.LogWarning("not implemented yet!");
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }

    public void AuthorsBtnClick()
    {
        Debug.LogWarning("not implemented yet!");
    }

    public void DebuStartGame()
    {
        SceneManager.LoadScene("Game");
    }

}