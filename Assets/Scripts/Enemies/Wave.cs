using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public bool ActivateAllSpawnersAtOnce;
    public float IntervalBetweenSpawns;
    public int EnemyCount;
    public EnemySpawner[] Spawners;
    public List<Enemy> Enemies;

    public void Init()
    {
        STF.WaveManager.InitWave(this);
    }
}