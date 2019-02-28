using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSkillManager : MonoBehaviour
{
    public UiSkill UiSkillPrefab;
    public Transform UiSkillsHolder;

    private Character character;
    private void Start()
    {
        character = STF.GameManager.Character;
        InitUiSkills();
    }

    private void InitUiSkills()
    {
        List<SkillData> skills = character.FightController.GetSkills();
        for (int i = 0; i < skills.Count; i++)
        {
            UiSkill uiSkill = Instantiate(UiSkillPrefab, UiSkillsHolder);
            uiSkill.InitSkillUi(skills[i]);
        }
    }
}