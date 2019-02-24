using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiProgressBar : MonoBehaviour
{
    //prefaba z tym skryptem trzeba mieć wyłączonego, bo będzie isOn na false, a tak naprawdę będzie włączony
    //można by to jakoś lepiej ogarnąć, ale ma to niskie prio

    public Image Bar;
    
    private Camera camera;
    private Transform objToFollow;

    private bool isInitialized;
    private bool isOn;

    public void Init(Transform objToFollow)
    {
        if (!isInitialized)
        {
            this.objToFollow = objToFollow;
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