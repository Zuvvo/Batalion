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
            Resource resource = STF.GameManager.ResourcesDB.Resources[i].Copy();
            resources.Add(resource.Id, resource);

            UiResource uiResource = Instantiate(UiResourcePrefab, STF.UiManager.ResourcesHolder);
            uiResource.Init(resource);
        }
    }

    public void AddResource(int id, float value)
    {
        if (resources.ContainsKey(id))
        {
            resources[id].AddAmount(value);
        }
    }
}