using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterProgress : MonoBehaviour
{
    public Image Bar;
    
    private Camera camera;
    private Transform objToFollow;


    private bool isInitialized;
    private bool isOn;

    public void Init(Transform objToFollow)
    {
        if (!isInitialized)
        {
            camera = Camera.main;
            isInitialized = true;
        }
    }

    public void SetObjectToFollow(Transform obj)
    {
        objToFollow = obj;
    }

    public void SetProgress(float value)
    {
        Bar.fillAmount = value;
    }

    public void SetActive(bool state)
    {
        if(state != isOn)
        {
            gameObject.SetActive(state);
            isOn = state;
        }
    }

    private void LateUpdate()
    {
        if (isOn)
        {
            transform.position = camera.WorldToScreenPoint(objToFollow.transform.position);
        }
    }
}