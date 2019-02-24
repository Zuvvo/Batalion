using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiUranDiggerController : MonoBehaviour
{
    [HideInInspector]
    public UiProgressBar UiProgressBar;

    [SerializeField]
    private UiProgressBar ProgressBarPrefab;

    private bool uiBarInitialized;

    public void SetUiHealth(float value)
    {
        if (!uiBarInitialized)
        {
            UiProgressBar = Instantiate(ProgressBarPrefab, STF.UiManager.UiProgressBarHolder);
            UiProgressBar.Init(transform);
            UiProgressBar.SetProgress(0);
            UiProgressBar.SetActive(true);
            uiBarInitialized = true;
        }
        UiProgressBar.SetProgress(value);
    }
}