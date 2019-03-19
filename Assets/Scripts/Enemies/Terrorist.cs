using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrorist : Enemy
{
    public float FireMinDistance = 3;
    public float FireMaxDistance = 6;

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
    private bool isShooting;

    private float direction;

    private Quaternion lookLeftRotation = new Quaternion(0, 0, 0, 0);
    private Quaternion lookRightRotation = new Quaternion(0, 180, 0, 0);

    protected override void Start()
    {
        base.Start();
        currentAmmo = maxAmmo;
        StartCoroutine(Jump());
        StartCoroutine(TryToShoot());
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
                transform.rotation = lookLeftRotation;
            }
            else
            {
                direction = 1;
                transform.rotation = lookRightRotation;
            }

            float distanceToPlayer = Vector2.Distance(STF.GameManager.Character.transform.position, transform.position);
          //  Debug.Log(distanceToPlayer);
            movementEnabled = distanceToPlayer >= FireMinDistance && !isShooting;
        }
    }

    private IEnumerator TryToShoot()
    {
        while (currentAmmo > 0)
        {
            yield return new WaitForSeconds(ShootDelay);
            float distanceToPlayer = Vector2.Distance(STF.GameManager.Character.transform.position, transform.position);

            if(distanceToPlayer <= FireMinDistance)
            {
                isShooting = true;
            }
            else if(isShooting && distanceToPlayer >= FireMaxDistance)
            {
                isShooting = false;
            }

            if (isShooting)
            {
                Bullet bulletPrefab = (Bullet)STF.GameManager.AmmoDB.GetEnemyAmmo(AmmoId);
                Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, STF.GameManager.BulletsHolder);
            }
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