using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranDiggerMovement : MonoBehaviour
{
    public Transform TooltipTransform;
    public Transform CharacterDragTransform;

    public bool IsMovementBlocked
    {
        get
        {
            return isMovementBlocked;

        }
        set
        {
            if (value)
            {
                ForceStopDragging();
            }
            isMovementBlocked = value;
        }
    }

    public event Action OnMovedForFirstTime;

    private string firstUseText = "Hold ctrl and left/right arrow to move digger";
    private bool isDragging;
    private bool isDraggingAllowed;
    private bool isMovedForFirstTime;

    private bool isDirectionLeft;

    private bool isMovementBlocked;


    private void Update()
    {
        if (IsMovementBlocked)
        {
            return;
        }

        if (isDraggingAllowed && Input.GetKey(KeyCode.LeftControl))
        {
            if (!DetermineDragDirection())
            {
                return;
            }

            if (!isDragging)
            {
                StartDragging();
            }
        }
        else
        {
            ForceStopDragging();
        }

        if (isDragging)
        {
            Transform charTransform = STF.GameManager.Character.transform;
            Vector3 directionVector = isDirectionLeft ? Vector3.left : Vector3.right;
            transform.Translate(directionVector * STF.GameManager.Character.Stats.DiggerDragSpeed, Space.World);
            charTransform.position = new Vector3(CharacterDragTransform.position.x, charTransform.position.y, charTransform.position.z);
        }
    }

    private void StartDragging()
    {
        STF.GameManager.Character.MovementController.SetMovementActive(false);
        STF.GameManager.Character.AnimatorController.SetState(AnimationState.Push);
        isDragging = true;
        if (!isMovedForFirstTime)
        {
            STF.UiManager.UiTooltip.SetActive(false);
            isMovedForFirstTime = true;
        }
    }

    private void ForceStopDragging()
    {
        if (isDragging)
        {
            STF.GameManager.Character.AnimatorController.SetState(AnimationState.Idle);
            STF.GameManager.Character.MovementController.SetMovementActive(true);
        }
    }

    private bool DetermineDragDirection()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            isDirectionLeft = false;
            return true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            isDirectionLeft = true;
            return true;
        }
        return false;
    }

    public void AllowToMove()
    {
        if (IsMovementBlocked)
        {
            return;
        }

        isDraggingAllowed = true;
        if (!isMovedForFirstTime)
        {
            STF.UiManager.UiTooltip.SetActive(true, TooltipTransform, firstUseText);
        }
    }

    public void DisallowToMove()
    {
        if (IsMovementBlocked)
        {
            return;
        }

        isDraggingAllowed = false;
        if (!isMovedForFirstTime)
        {
            STF.UiManager.UiTooltip.SetActive(false);
        }
    }
}