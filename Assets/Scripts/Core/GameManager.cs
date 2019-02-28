using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraSystem CameraSystem;
    public InputController InputController;
    public Character Character;
    public SpawnerManager SpawnerManager;
    public CutsceneManager CutsceneManager;
    public AttacksDB AttacksDB;

    private void OnLevelWasLoaded(int level)
    {
        STF.NullReferences();
    }
}