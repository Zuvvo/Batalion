using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTooltip : MonoBehaviour
{
    public TextMeshProUGUI Text;

    private bool isOn;
    private Transform objToFollow;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    public void SetActive(bool state, Transform objectToFollow, string toolTipText)
    {
        Text.text = toolTipText;
        objToFollow = objectToFollow;
        isOn = state;
        gameObject.SetActive(state);
    }

    public void SetActive(bool state)
    {
        isOn = state;
        gameObject.SetActive(state);
    }

    private void Update()
    {
        if (isOn)
        {
            transform.position = camera.WorldToScreenPoint(objToFollow.transform.position);
        }
    }
}
