using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranDigger : MonoBehaviour
{
    public UranDiggerMovement MovementController;
    public UranDiggerRepairing Repairing;
    public UiUranDiggerController UiUranDigger;

    public Transform AlertTransform;

    private float destroyedInfoTime = 4;
    private string destroyedInfo = "Ooops, digger got damaged. Hold E to repair it.";

    private void Start()
    {
        Repairing.OnDiggerRepaired += () => SetDiggerDestroyed(false);
        Repairing.OnDiggerHealthChanged += () => UiUranDigger.SetUiHealth(Repairing.ActualHealth / Repairing.MaxHealth);
    }

    public void SetDiggerDestroyed(bool state = true)
    {
        Repairing.SetToRepair(state);
        MovementController.IsMovementBlocked = state;

        if (state)
        {
            STF.UiManager.UiAlert.SetActive(true, AlertTransform, destroyedInfo);
            STF.UiManager.UiAlert.SetOff(destroyedInfoTime);
        }
    }
}