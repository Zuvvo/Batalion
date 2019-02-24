using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BitStrap;

public class InputController : MonoBehaviour
{
    private Dictionary<MyKeyCode, List<KeyCode>> keysTranslate = new Dictionary<MyKeyCode, List<KeyCode>>()
    {
        { MyKeyCode.Left, new List<KeyCode>() {KeyCode.A, KeyCode.LeftArrow } },
        { MyKeyCode.Right, new List<KeyCode>() {KeyCode.D, KeyCode.RightArrow } },
        { MyKeyCode.Down, new List<KeyCode>() {KeyCode.S, KeyCode.DownArrow } },
        { MyKeyCode.Up, new List<KeyCode>() {KeyCode.W, KeyCode.UpArrow } },
        { MyKeyCode.Jump, new List<KeyCode>() {KeyCode.Space} },
        { MyKeyCode.Interaction, new List<KeyCode>() {KeyCode.E } },
        { MyKeyCode.Drag, new List<KeyCode>() {KeyCode.LeftControl } },
    };

    private Dictionary<MyKeyCode, SafeAction> keyUpActions = new Dictionary<MyKeyCode, SafeAction>();
    private Dictionary<MyKeyCode, SafeAction> keyDownActions = new Dictionary<MyKeyCode, SafeAction>();
    private Dictionary<MyKeyCode, bool> keyHeld = new Dictionary<MyKeyCode, bool>();

    private bool isInitialized;

    private bool keyPressed;
    private bool keyDown;
    private bool keyUp;

    public bool IsKeyHeld(MyKeyCode key)
    {
        return keyHeld[key];
    }

    ///<summary>
    ///True if you want to register Action on Key Down. False if on Key Up.
    ///</summary>
    public void RegisterKeyAction(MyKeyCode key, bool state, Action action)
    {
        if (!isInitialized)
        {
            InitKeysDict();
        }

        if (state)
        {
            keyDownActions[key].Register(action);
        }
        else
        {
            keyUpActions[key].Register(action);
        }
    }
    ///<summary>
    ///True if you want to register Action on Key Down. False if on Key Up.
    ///</summary>
    public void UnregisterKeyAction(MyKeyCode key, bool state, Action action)
    {
        if (state)
        {
            if (keyDownActions.ContainsKey(key))
            {
                keyDownActions[key].Unregister(action);
            }
        }
        else
        {
            if (keyUpActions.ContainsKey(key))
            {
                keyUpActions[key].Unregister(action);
            }
        }
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
            keyUpActions.Add((MyKeyCode)i, new SafeAction());
            keyDownActions.Add((MyKeyCode)i, new SafeAction());
            keyHeld.Add((MyKeyCode)i, false);
        }
        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized)
        {
            InitKeysDict();
        }
        SetKeysValues();
        TriggerKeyActions();
    }

    private void TriggerKeyActions()
    {

    }

    private void SetKeysValues()
    {
        foreach (KeyValuePair<MyKeyCode, List<KeyCode>> keyPair in keysTranslate)
        {
            keyPressed = false;
            keyUp = false;
            keyDown = false;
            for (int i = 0; i < keyPair.Value.Count; i++)
            {
                if (Input.GetKey(keyPair.Value[i]))
                {
                    keyPressed = true;
                }
                if (Input.GetKeyDown(keyPair.Value[i]))
                {
                    keyDown = true;
                }
                if (Input.GetKeyUp(keyPair.Value[i]))
                {
                    keyUp = true;
                }
            }
            keyHeld[keyPair.Key] = keyPressed;
            if (keyUp)
            {
                keyUpActions[keyPair.Key].Call();
            }
            if (keyDown)
            {
                keyDownActions[keyPair.Key].Call();
            }

        }
    }
}

public static class InputExtensions
{
    public static bool IsKeyHeld(this MyKeyCode key)
    {
        return STF.GameManager.InputController.IsKeyHeld(key);
    }
}
 