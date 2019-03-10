﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWork : MonoBehaviour
{
    public Transform ProgressBarTransform;

    private bool isWorking;

    private float workTime;
    private float workCurrentTime;
    private int workTicks;

    private event Action callbackOnWorkEnded;
    private event Action callbackOnTickEnded;

    private void Update()
    {
        if (isWorking)
        {
            workCurrentTime += Time.deltaTime;
            STF.UiManager.UiCharacterProgress.SetProgress(workCurrentTime / workTime);
            if (workCurrentTime >= workTime)
            {
                workCurrentTime = 0;
                EndWorkTick();
            }
        }
    }

    public void StartWork(float workTime, int ticks = 1, Action callbackOnWorkEnded = null, Action callbackOnTickEnded = null)
    {
        Debug.Log("start work time: " + workTime);
        STF.UiManager.UiCharacterProgress.SetObjectToFollow(ProgressBarTransform);
        STF.UiManager.UiCharacterProgress.SetActive(true);
        this.workTime = workTime;
        this.callbackOnTickEnded = callbackOnTickEnded;
        this.callbackOnWorkEnded = callbackOnWorkEnded;
        workTicks = ticks;
        isWorking = true;
    }

    public void ForceStopWork()
    {
        STF.UiManager.UiCharacterProgress.SetActive(false);
        workCurrentTime = 0;
        workTime = 0;
        isWorking = false;
    }

    private void EndWorkTick()
    {
        workTicks--;
        if (callbackOnTickEnded != null)
        {
            callbackOnTickEnded();
        }
        if (workTicks <= 0)
        {
            WorkPositiveEnded();
        }
    }

    private void WorkPositiveEnded()
    {
        ForceStopWork();
        if (callbackOnWorkEnded != null)
        {
            callbackOnWorkEnded();
        }
    }
}