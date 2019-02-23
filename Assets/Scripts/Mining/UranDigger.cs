using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranDigger : MonoBehaviour
{
    public bool MovedForFirstTime;
    public Transform TooltipTransform;
    public Transform CharacterDragTransform;

    private string firstUseText = "Press ctrl + right arrow to move digger";
    private bool isDragging;
    private Character draggingCharacter;
    private bool isDraggingAllowed;

    private void Update()
    {
        if (isDraggingAllowed && Input.GetKey(KeyCode.LeftControl) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            STF.GameManager.Character.MovementController.SetMovementActive(false);
            isDragging = true;
            if (!MovedForFirstTime)
            {
                STF.UiManager.UiTooltip.SetActive(false);
                MovedForFirstTime = true;
            }
        }
        else
        {
            STF.GameManager.Character.MovementController.SetMovementActive(true);
            isDragging = false;
        }

        if (isDragging)
        {
            Transform charTransform = STF.GameManager.Character.transform;
            transform.Translate(Vector3.right * STF.GameManager.Character.Stats.DiggerDragSpeed, Space.World);
            charTransform.position =  new Vector3(CharacterDragTransform.position.x, charTransform.position.y, charTransform.position.z);
        }
    }

    public void AllowToMove()
    {
        isDraggingAllowed = true;
        if (!MovedForFirstTime)
        {
            STF.UiManager.UiTooltip.SetActive(true, TooltipTransform, firstUseText);
        }
    }

    public void DisallowToMove()
    {
        isDraggingAllowed = false;
        if (!MovedForFirstTime)
        {
            STF.UiManager.UiTooltip.SetActive(false);
        }
    }
}