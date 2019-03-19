using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> Waves = new List<Wave>();

    private Wave actualWave;

    public void InitFirstWaveOnList()
    {
        if(Waves.Count > 0)
        {
            Waves[0].Init();
        }
    }

    public void InitWave(Wave wave)
    {
        actualWave = wave;
        Waves.Remove(wave);
        StartCoroutine(StartActualWave());
    }

    private IEnumerator StartActualWave()
    {
        int enemyCount = actualWave.EnemyCount;
        while(enemyCount > 0)
        {
            if (actualWave.ActivateAllSpawnersAtOnce)
            {
                for (int j = 0; j < actualWave.Spawners.Length; j++)
                {
                    actualWave.Spawners[j].Spawn();
                    enemyCount--;
                    if(enemyCount <= 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                int randomSpawner = UnityEngine.Random.Range(0, actualWave.Spawners.Length - 1);
                actualWave.Spawners[randomSpawner].Spawn();
                enemyCount--;
            }
            yield return new WaitForSeconds(actualWave.IntervalBetweenSpawns);
        }
    }
}