﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranDiggerRepairing : MonoBehaviour
{
    public GameObject DestroyedModel;
    public GameObject RepairedModel;

    public float MaxHealth;
    public float StartHealth;
    
    public float ActualHealth;

    public event Action OnDiggerRepaired;

    public event Action OnDiggerHealthChanged;

    private bool isDestroyed;
    private bool isBeingRepaired;
    private bool characterInTrigger;

    private Character repairingCharacter;

    public float HealthPercent
    {
        get
        {
            return ActualHealth / MaxHealth;
        }
    }

    
    private void Start()
    {
        ActualHealth = StartHealth;
    }

    private void Update()
    {
        if(characterInTrigger && isDestroyed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isBeingRepaired = true;
                repairingCharacter.Action.StartRepairing(this);
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                isBeingRepaired = false;
                repairingCharacter.Action.StopRepairing(this);
            }
        }
    }

    public void ChangeHealth(float change)
    {
        ActualHealth += change;
        ActualHealth = Mathf.Clamp(ActualHealth, 0, MaxHealth);

        CallOnHealthChanged();
        if (ActualHealth == MaxHealth && isDestroyed)
        {
            Debug.Log("repaired");
            SetToRepair(false);
            CallOnRepaired();
        }
    }

    public void CharacterTriggerEnterExit(Character character, bool characterEntered)
    {
        if (!characterEntered && isBeingRepaired)
        {
            isBeingRepaired = false;
            repairingCharacter.Action.StopRepairing(this);
        }
        repairingCharacter = character;
        characterInTrigger = characterEntered;
    }

    public void SetToRepair(bool state = true)
    {
        isDestroyed = state;
        DestroyedModel.SetActive(state);
        RepairedModel.SetActive(!state);

        if (isDestroyed)
        {
            ActualHealth = 0;
        }
    }

    private void CallOnRepaired()
    {
        if(OnDiggerRepaired != null)
        {
            OnDiggerRepaired();
        }
    }

    private void CallOnHealthChanged()
    {
        if(OnDiggerHealthChanged != null)
        {
            OnDiggerHealthChanged();
        }
    }
}
