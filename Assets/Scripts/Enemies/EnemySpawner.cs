using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int Id;
    public SpriteRenderer DebugColor;

    private void Start()
    {
        DebugColor.enabled = false;
     //   SetActive(true);
        STF.SpawnerManager.RegisterSpawner(this);
    }

    public void Spawn()
    {
        STF.SpawnerManager.InstantiateEnemyWithId(Id, transform.position, Quaternion.identity);
    }
}