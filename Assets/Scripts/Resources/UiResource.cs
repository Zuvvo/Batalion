using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiResource : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI Amount;

    private Resource resource;

    public void Init(Resource resource)
    {
        this.resource = resource;
        Icon.sprite = resource.Icon;
        resource.OnResourceChanged += UpdateValues;
        UpdateValues();
    }

    private void UpdateValues()
    {
        Amount.text = string.Format("{0}/{1}", (int)resource.Amount, (int)resource.MaxAmount);
    }
}