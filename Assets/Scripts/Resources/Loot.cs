using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public List<RandomValue> RandomDrop;

    private void OnDestroy()
    {
        ApplyLoot();
    }

    public void ApplyLoot()
    {
        for (int i = 0; i < RandomDrop.Count; i++)
        {
            AddSingleResource(RandomDrop[i]);
        }
    }

    private void AddSingleResource(RandomValue resource)
    {
        if(resource.Max >= resource.Min)
        {
            int value = Random.Range(resource.Min, resource.Max);
            STF.Player.Resources.AddResource(resource.Id, value);
        }
        else
        {
            Debug.LogWarning("Wrong resource values!");
        }
    }
}