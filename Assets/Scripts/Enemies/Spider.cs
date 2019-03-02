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

    private float direction;

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
            Character character = STF.GameManager.Character;

            yield return new WaitForSeconds(0.1f);

            Vector2 enemyToPlayer = (Vector2)transform.position - (Vector2)character.transform.position;
            if (enemyToPlayer.x > 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }

            float distanceToPlayer = Vector2.Distance(STF.GameManager.Character.transform.position, transform.position);

            movementEnabled = distanceToPlayer >= DistanceToShoot;
        }
    }

    private IEnumerator Shoot()
    {
        while (currentAmmo > 0)
        {
            yield return new WaitForSeconds(ShootDelay);
            Bullet bulletPrefab = (Bullet)STF.GameManager.AmmoDB.GetEnemyAmmo(AmmoId);
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, STF.GameManager.BulletsHolder);
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
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (movementEnabled)
        {
            transform.position = transform.position + new Vector3(direction, 0, 0) * MoveSpeed * Time.deltaTime;
        }
    }
}