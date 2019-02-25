using System.Collections;
using System.Collections.Generic;
using BitStrap;
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
        else if(!MyKeyCode.Right.IsKeyHeld() && !MyKeyCode.Left.IsKeyHeld())
        {
            ParticleSystem.Stop();
        }
    }

    private void RotateChange(MyKeyCode key)
    {
        if (key.Equals(MyKeyCode.Left))
        {
            ParticleSystem.shape.rotation.Set(0, 0, 75);
        }
        else
        {
            ParticleSystem.shape.rotation.Set(0, 0, -75);
        }
    }

    private void Start()
    {
        ParticleSetActive(false);

        //STF.InputController.RegisterKeyAction(MyKeyCode.Left, true, () => ParticleSystem.shape.rotation.Set(0, 0, 75));
        STF.InputController.RegisterKeyAction(MyKeyCode.Left, true, () => RotateChange(MyKeyCode.Left));
        STF.InputController.RegisterKeyAction(MyKeyCode.Left, true, () => ParticleSetActive(true));

        //STF.InputController.RegisterKeyAction(MyKeyCode.Right, true, () => ParticleSystem.shape.rotation.Set(0, 0, -75));
        STF.InputController.RegisterKeyAction(MyKeyCode.Right, true, () => ParticleSetActive(true));
        STF.InputController.RegisterKeyAction(MyKeyCode.Left, true, () => RotateChange(MyKeyCode.Right));


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