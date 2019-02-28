using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackBehaviour : AttackBehaviour
{
    private Vector3 direction;

    protected override void Start()
    {
        base.Start();
        Vector3 mousePos = STF.Camera.ScreenToWorldPoint(Input.mousePosition);
        direction = ((Vector2)mousePos - (Vector2)STF.GameManager.Character.FightController.ShotStartPoint.position).normalized;
        Debug.Log(direction);
    }

    private void Update()
    {
        transform.position = transform.position + direction * Speed * Time.deltaTime;
    }
}