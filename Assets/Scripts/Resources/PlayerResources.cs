using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public UiResource UiResourcePrefab;

    private Dictionary<int, Resource> resources = new Dictionary<int, Resource>();

    private void Start()
    {
        CreatePlayerResourcesAndUi();
    }

    private void CreatePlayerResourcesAndUi()
    {
        for (int i = 0; i < STF.GameManager.ResourcesDB.Resources.Count; i++)
        {
            Resource resource = STF.GameManager.ResourcesDB.Resources[i];
            resources.Add(resource.Id, resource.Copy());

            UiResource uiResource = Instantiate(UiResourcePrefab, STF.UiManager.ResourcesHolder);
            uiResource.Init(resource);
        }
    }

    public void AddUranium(float value)
    {
        resources[0].AddAmount(value);
    }

    public void AddGold(float value)
    {
        resources[1].AddAmount(value);
    }
}