using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int Id;
    public float SpawnDelay;
    public SpriteRenderer DebugColor;

    private bool isSpawning;

    private void Start()
    {
        DebugColor.enabled = false;
     //   SetActive(true);
        STF.SpawnerManager.RegisterSpawner(this);
    }

    public void SetActive(bool state)
    {
        isSpawning = state;

        if (isSpawning)
        {
            StartCoroutine(SpawnEnemy());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            STF.SpawnerManager.InstantiateEnemyWithId(Id, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}