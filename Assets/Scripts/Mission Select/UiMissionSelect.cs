using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMissionSelect : MonoBehaviour
{
    public void SelectMissionBtnClick(int missionId)
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenuBtnClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }
}