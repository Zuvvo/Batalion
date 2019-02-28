using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float power = 9.0f;
    public Rigidbody2D bullet;

    void Start()
    {
        Vector2 vec = new Vector2(-0.02f, 0.002f);
        bullet.AddForce(vec * power, ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(bullet.gameObject);
    }
}
