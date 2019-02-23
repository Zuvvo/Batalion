using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranDiggerTrigger : MonoBehaviour
{
    public UranDigger UranDigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            UranDigger.AllowToMove();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UranDigger.DisallowToMove();
    }
}