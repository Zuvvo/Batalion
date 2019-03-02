using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public int Id;
    public AttackBehaviour Behaviour;
    private float damage;

    public void InitData(float damage)
    {
        this.damage = damage;
    }
}