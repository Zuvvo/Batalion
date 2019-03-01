using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Id;

    private void OnDestroy()
    {
        STF.GameManager.SpawnerManager.Enemies.Remove(this);
    }
}