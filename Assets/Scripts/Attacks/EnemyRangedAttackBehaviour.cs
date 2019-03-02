using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttackBehaviour : RangedAttackBehaviour
{
    protected override void Start()
    {
        StarTop();
        direction = (STF.GameManager.Character.transform.position - transform.position).normalized;
    }

}