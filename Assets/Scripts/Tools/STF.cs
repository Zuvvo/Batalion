using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class STF // Static Tag (Object) Finder
{
    private static GameManager _gm;
    public static GameManager GameManager
    {
        get
        {
            return _gm ?? (_gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>());
        }
    }

    private static UiManager _uiManager;
    public static UiManager UiManager
    {
        get
        {
            return _uiManager ?? (_uiManager = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UiManager>());
        }
    }

    private static InputController _inputController;
    public static InputController InputController
    {
        get
        {
            return _inputController ?? (_inputController = GameManager.InputController);
        }
    }

    public static void NullReferences()
    {
        _inputController = null;
        _uiManager = null;
        _gm = null;
    }
}
