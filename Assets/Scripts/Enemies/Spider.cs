using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    public float DistanceToShoot = 5;

    public float MoveSpeed;

    public float JumpDelay;
    public float ShootDelay;
    public int AmmoId;

    public float JumpPower;
    public Rigidbody2D RigidBody2D;

    private int maxAmmo = 500;
    private int currentAmmo;

    private List<Bullet> bullets = new List<Bullet>();

    private bool movementEnabled = true;

    private void Start()
    {
        currentAmmo = maxAmmo;
        StartCoroutine(Jump());
        StartCoroutine(Shoot());
        StartCoroutine(CheckForDistanceToPlayer());
    }

    private IEnumerator CheckForDistanceToPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            float distanceToPlayer = Vector2.Distance(STF.GameManager.Character.transform.position,transform.position);

            movementEnabled = distanceToPlayer >= DistanceToShoot;
        }
    }

    private IEnumerator Shoot()
    {
        while(currentAmmo > 0)
        {
            yield return new WaitForSeconds(ShootDelay);
            Bullet bulletPrefab = (Bullet)STF.GameManager.AmmoDB.GetEnemyAmmo(AmmoId);
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, STF.GameManager.BulletsHolder);
           // bullet.AddStartFoce(new Vector2(-0.02f, 0.01f), 7);
        }
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
        if (movementEnabled)
        {
            float force = MoveSpeed * Time.deltaTime;
            RigidBody2D.AddForce(Vector2.left * force);
        }
    }
}