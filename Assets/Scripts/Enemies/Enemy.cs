using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Id;

    public float StartHealth;

    private float health;

    protected virtual void Start()
    {
        health = StartHealth;
    }

    public void ApplyDamage(float value)
    {
        health -= value;
        if(health <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        STF.GameManager.SpawnerManager.Enemies.Remove(this);
    }
}