using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character Character;

    public CameraSystem CameraSystem;
    public InputController InputController;
    public SpawnerManager SpawnerManager;
    public CutsceneManager CutsceneManager;

    public AttacksDB AttacksDB;
    public AmmoDB AmmoDB;
    public ResourcesDatabase ResourcesDB;

    public Transform BulletsHolder;

    private void OnLevelWasLoaded(int level)
    {
        STF.NullReferences();
    }
}