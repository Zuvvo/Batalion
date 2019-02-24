using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDiggerTrigger : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Digger"))
        {
            UranDigger digger = collision.GetComponentInParent<UranDigger>();
            digger.SetDiggerDestroyed();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpriteRenderer.enabled = false;
    }
}
