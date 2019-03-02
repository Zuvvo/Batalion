using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttackBehaviour : AttackBehaviour
{
    private void Update()
    {
        transform.position = transform.position + Vector3.right * Speed * Time.deltaTime;
    }
}