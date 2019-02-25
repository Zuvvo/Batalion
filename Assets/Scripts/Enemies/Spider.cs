using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    public float MoveSpeed;
    public float JumpDelay;
    public float JumpPower;
    public Rigidbody2D RigidBody2D;

    private void Start()
    {
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        while (true)
        {
            yield return new WaitForSeconds(JumpDelay);
            RigidBody2D.AddForce(Vector2.up * JumpPower);
         //   Debug.Log("HOP!");
        }
    }

    private void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        // RigidBody
        float force = MoveSpeed * Time.deltaTime;
        RigidBody2D.AddForce(Vector2.left * force);
    }
}