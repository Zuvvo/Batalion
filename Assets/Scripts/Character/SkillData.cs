using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillData
{
    public int Id;
    public float Damage;
    public float Cooldown;
    public Sprite Icon;
    public int SkillEffectId;

    public event Action<float> OnCdChanged;
    private float actualCd;

    [HideInInspector]
    public float ActualCd
    {
        get
        {
            return actualCd;
        }
        set
        {
            actualCd = value;
            CallOnCdChanged();
        }
    }
    
    private void CallOnCdChanged()
    {
        if(OnCdChanged != null)
        {
            OnCdChanged(ActualCd / Cooldown);
        }
    }
}