using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cutscene : MonoBehaviour
{
    public int Id;

    protected bool isPlaying;

    protected Camera camera;
    protected CameraSystem cameraSystem;
    

    private void Start()
    {
        camera = Camera.main;
        cameraSystem = STF.CameraSystem;
    }

    protected abstract void OnCutsceneStarted();

    protected abstract void OnCutsceneStopped();

    public virtual void Play()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            OnCutsceneStarted();
        }
    }

    public virtual void Stop()
    {
        if (isPlaying)
        {
            isPlaying = false;
            OnCutsceneStopped();
        }
    }
}