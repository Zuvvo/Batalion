using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAttackCutscene : Cutscene
{
    public Animator Animator;

    [SerializeField]
    private List<EnemySpawner> spawners;
    protected override void OnCutsceneStarted()
    {
        Animator.enabled = true;
    }

    protected override void OnCutsceneStopped()
    {
        Animator.enabled = false;
    }

    protected void StartSpawning()
    {
        for (int i = 0; i < spawners.Count; i++)
        {
            spawners[i].SetActive(true);
        }
    }
}
