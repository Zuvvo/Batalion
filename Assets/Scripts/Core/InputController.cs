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
        { MyKeyCode.Attack1, new List<KeyCode>() {KeyCode.Alpha1 } },
        { MyKeyCode.Attack2, new List<KeyCode>() {KeyCode.Alpha2 } },
    };

    private Dictionary<MyKeyCode, SafeAction> keyUpActions = new Dictionary<MyKeyCode, SafeAction>();
    private Dictionary<MyKeyCode, SafeAction> keyDownActions = new Dictionary<MyKeyCode, SafeAction>();
    private Dictionary<MyKeyCode, bool> keyHeld = new Dictionary<MyKeyCode, bool>();

    private Dictionary<MouseButton, SafeAction> mouseUpActions = new Dictionary<MouseButton, SafeAction>();
    private Dictionary<MouseButton, SafeAction> mouseDownActions = new Dictionary<MouseButton, SafeAction>();
    private Dictionary<MouseButton, bool> mouseHeld = new Dictionary<MouseButton, bool>();

    private bool isInitialized;

    private bool keyPressed;
    private bool keyDown;
    private bool keyUp;

    private bool mousePressed;
    private bool mouseDown;
    private bool mouseUp;

    private int mouseButtons;

    private void Start()
    {
        InitKeysDict();
    }

    private void Update()
    {
        if (!isInitialized)
        {
            InitKeysDict();
        }
        SetKeysValues();
        SetMouseValues();
    }

    #region Registering
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
    ///True if you want to unregister Action on Key Down. False if on Key Up.
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

    ///<summary>
    ///True if you want to register an action on mouse button pressed down. False if pressed up.
    ///</summary>
    public void RegisterMouseAction(MouseButton button, bool state, Action action)
    {
        if (!isInitialized)
        {
            InitKeysDict();
        }

        if (state)
        {
            if (mouseDownActions.ContainsKey(button))
            {
                mouseDownActions[button].Register(action);
            }
        }
        else
        {
            if (mouseUpActions.ContainsKey(button))
            {
                mouseUpActions[button].Register(action);
            }
        }
    }

    ///<summary>
    ///True if you want to unregister an action on mouse button pressed down. False if pressed up.
    ///</summary>
    public void UnregisterMouseAction(MouseButton button, bool state, Action action)
    {
        if (state)
        {
            if (mouseDownActions.ContainsKey(button))
            {
                mouseDownActions[button].Unregister(action);
            }
        }
        else
        {
            if (mouseUpActions.ContainsKey(button))
            {
                mouseUpActions[button].Unregister(action);
            }
        }
    }
    #endregion

    private void InitKeysDict()
    {
        if (!isInitialized)
        { 
            //keyboard initializing
            int keysCount = Enum.GetValues(typeof(MyKeyCode)).Length;
            for (int i = 0; i < keysCount; i++)
            {
                keyUpActions.Add((MyKeyCode)i, new SafeAction());
                keyDownActions.Add((MyKeyCode)i, new SafeAction());
                keyHeld.Add((MyKeyCode)i, false);
            }

            //mouse initializing
            mouseButtons = Enum.GetValues(typeof(MouseButton)).Length;
            for (int i = 0; i < mouseButtons; i++)
            {
                mouseUpActions.Add((MouseButton)i, new SafeAction());
                mouseDownActions.Add((MouseButton)i, new SafeAction());
                mouseHeld.Add((MouseButton)i, false);
            }
            isInitialized = true;
        }
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

    private void SetMouseValues()
    {
        for (int i = 0; i < mouseButtons; i++)
        {
            MouseButton button = (MouseButton)i;
            mouseHeld[button] = Input.GetMouseButton(i);
            if (Input.GetMouseButtonDown((i)))
            {
                mouseDownActions[button].Call();
            }
            if (Input.GetMouseButtonUp((i)))
            {
                mouseUpActions[button].Call();
            }
        }
    }

    public bool IsKeyHeld(MyKeyCode key)
    {
        if (isInitialized)
        {
            return keyHeld[key];
        }
        return false;
    }

    public bool IsMouseHeld(MouseButton button)
    {
        if (isInitialized)
        {
            return mouseHeld[button];
        }
        return false;
    }
}

public static class InputExtensions
{
    public static bool IsKeyHeld(this MyKeyCode key)
    {
        return STF.GameManager.InputController.IsKeyHeld(key);
    }
}