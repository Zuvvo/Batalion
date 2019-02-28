using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    public float Speed;
    public float DestroyTime;

    protected virtual void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}