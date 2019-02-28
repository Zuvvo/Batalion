using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSkill : MonoBehaviour
{
    public Image SkillImage;
    public Image CdImage;
    public Button SkillButton;

    private SkillData skillData;

    public void InitSkillUi(SkillData data)
    {
        skillData = data;
        data.OnCdChanged += SetCdImage;
        SkillImage.sprite = skillData.Icon;
        SkillButton.onClick.RemoveAllListeners();
        //SkillButton.onClick.AddListener(() => STF.GameManager.Character.FightController.InitAttackWithId(data.Id));

    }

    private void SetCdImage(float percent)
    {
        CdImage.fillAmount = percent;
    }
}