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
    public AmmoDB AmmoDB;

    public Transform BulletsHolder;

    private void OnLevelWasLoaded(int level)
    {
        STF.NullReferences();
    }
}