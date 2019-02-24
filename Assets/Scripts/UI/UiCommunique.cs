using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCommunique : MonoBehaviour
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

    public void SetOff(float delayTime)
    {
        StartCoroutine(SetOffDelay(delayTime));
    }

    private IEnumerator SetOffDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetActive(false);
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
