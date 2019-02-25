﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffects : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    private void ParticleSetActive(bool state)
    {
        if (state)
        {
            ParticleSystem.Play();
        }
        else
        {
            if(!MyKeyCode.Left.IsKeyHeld() && !MyKeyCode.Right.IsKeyHeld())
            {
                ParticleSystem.Stop();
            }
        }
    }

    private void Start()
    {
        STF.InputController.RegisterKeyAction(MyKeyCode.Left, true, () => ParticleSetActive(true));
        STF.InputController.RegisterKeyAction(MyKeyCode.Right, true, () => ParticleSetActive(true));

        STF.InputController.RegisterKeyAction(MyKeyCode.Left, false, () => ParticleSetActive(false));
        STF.InputController.RegisterKeyAction(MyKeyCode.Right, false, () => ParticleSetActive(false));
    }

    public void StartParticles()
    {

    }

    public void StopParticles()
    {

    }
}