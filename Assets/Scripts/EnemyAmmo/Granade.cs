using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : EnemyAmmo
{
    private float power = 3.0f;
    private int timeCounter;
    private int timeLimit = 120;
    public Rigidbody2D granade;

    void Start()
    {
        Vector2 vec = new Vector2(-0.2f, 0.1f);
        granade.AddForce(vec * power, ForceMode2D.Impulse);
    }

    void Update()
    {
        timeCounter++;
        if (timeCounter > timeLimit)
        {
            granade.gameObject.SetActive(false);
            Destroy(granade.gameObject);
        }
    }
}
