using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Dictionary<MyKeyCode, List<KeyCode>> keysTranslate = new Dictionary<MyKeyCode, List<KeyCode>>();

    public bool IsKeyHeld(MyKeyCode key)
    {
        return true;
    }

    private void Start()
    {
        InitKeysDict();
    }

    private void InitKeysDict()
    {
        int keysCount = Enum.GetValues(typeof(MyKeyCode)).Length;
        for (int i = 0; i < keysCount; i++)
        {

        }
    }

    private void Update()
    {
        
    }

}

public static class InputExtensions
{
    public static bool IsKeyHeld(this MyKeyCode key)
    {
        return STF.GameManager.InputController.IsKeyHeld(key);
    }
}