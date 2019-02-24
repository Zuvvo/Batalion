using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterProgress : MonoBehaviour
{
    public Image Bar;
    
    private Camera camera;

    private bool isInitialized;

    public void Init(Transform objToFollow)
    {
        if (!isInitialized)
        {
            camera = Camera.main;
            isInitialized = true;
        }
    }

    public void SetProgress(float value, Vector3 barPosition)
    {
        transform.position = camera.WorldToScreenPoint(barPosition);
        Bar.fillAmount = value;
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

    private void Update()
    {
    }
}