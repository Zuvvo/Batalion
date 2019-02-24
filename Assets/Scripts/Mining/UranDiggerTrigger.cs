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
            Character character = collision.GetComponent<Character>();
            UranDigger.MovementController.AllowToMove();
            UranDigger.Repairing.CharacterTriggerEnterExit(character, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();
        UranDigger.MovementController.DisallowToMove();
        UranDigger.Repairing.CharacterTriggerEnterExit(character, false);
    }
}