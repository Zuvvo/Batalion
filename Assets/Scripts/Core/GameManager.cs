using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraSystem CameraSystem;
    public Character Character;

    private void OnLevelWasLoaded(int level)
    {
        STF.NullReferences();
    }
}