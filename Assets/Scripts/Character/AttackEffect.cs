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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Enemy enemy = collision.collider.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.ApplyDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}