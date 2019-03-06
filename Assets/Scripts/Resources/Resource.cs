using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    public Sprite Icon;
    public float MaxAmount;
    public int Id;
    public string Name;
    public float Amount;

    public Action OnResourceChanged;

    public void AddAmount(float value)
    {
        Amount += value;
        if(Amount>= MaxAmount)
        {
            Amount = MaxAmount;
            Debug.Log("Max value reached");
        }
        CallOnResourceStateChanged();
    }

    private void CallOnResourceStateChanged()
    {
        if(OnResourceChanged != null)
        {
            OnResourceChanged();
        }
    }

    public Resource Copy()
    {
        return new Resource()
        {
            Amount = this.Amount,
            Icon = this.Icon,
            MaxAmount = this.MaxAmount,
            Id = this.Id,
            Name = this.Name
        };
    }
}