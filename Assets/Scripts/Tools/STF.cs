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

    private static SpawnerManager _spawnerManager;
    public static SpawnerManager SpawnerManager
    {
        get
        {
            return _spawnerManager ?? (_spawnerManager = GameManager.SpawnerManager);
        }
    }

    private static CameraSystem _cameraSystem;
    public static CameraSystem CameraSystem
    {
        get
        {
            return _cameraSystem ?? (_cameraSystem = GameManager.CameraSystem);
        }
    }

    private static CutsceneManager _cutsceneManager;
    public static CutsceneManager CutsceneManager
    {
        get
        {
            return _cutsceneManager ?? (_cutsceneManager = GameManager.CutsceneManager);
        }
    }

    private static Camera _camera;
    public static Camera Camera
    {
        get
        {
            return _camera ?? (_camera = Camera.main);
        }
    }

    private static Player _player;
    public static Player Player
    {
        get
        {
            return _player ?? (_player = Object.FindObjectOfType<Player>());
        }
    }

    public static void NullReferences()
    {
        _gm = null;
        _uiManager = null;
        _inputController = null;
        _spawnerManager = null;
        _cameraSystem = null;
        _cutsceneManager = null;
        _camera = null;
    }
}
