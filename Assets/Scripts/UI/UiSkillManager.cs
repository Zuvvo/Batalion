using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSkillManager : MonoBehaviour
{
    private Character character;
    private void Start()
    {
        character = STF.GameManager.Character;
        InitUiSkills();
    }

    private void InitUiSkills()
    {

    }
}