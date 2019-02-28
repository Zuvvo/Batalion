using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffectBehaviour : MonoBehaviour
{
    private float speed = 10;
    private float destroyTime = 2;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
    }
}