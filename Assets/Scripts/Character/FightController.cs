using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    [SerializeField]
    private List<SkillData> skills;

    private Dictionary<int, SkillData> skillsDict = new Dictionary<int, SkillData>();

    private void Start()
    {
        STF.InputController.RegisterKeyAction(MyKeyCode.Attack1, true, () => InitAttackWithId(0));
        STF.InputController.RegisterKeyAction(MyKeyCode.Attack2, true, () => InitAttackWithId(1));
        InitSkillsDict();
    }

    private void Update()
    {
        UpdateSkillsCooldown();
    }

    public List<SkillData> GetSkills()
    {
        return skills;
    }

    public void InitAttackWithId(int id)
    {
        SkillData data = skillsDict[id];
        Debug.Log(data.Cooldown + "   " + data.ActualCd);
        if (data.ActualCd == 0)
        {
            data.ActualCd = data.Cooldown;
            AttackEffect attackEffectPrefab = STF.GameManager.AttacksDB.GetAttackEffectWithId(data.SkillEffectId);
            AttackEffect attack = Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
            attack.InitData(data.Damage);
            Debug.Log("Attack " + id + " damage: " + data.Damage);

        }
    }

    private void UpdateSkillsCooldown()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            SkillData skill = skills[i];
            if (skill.ActualCd > 0)
            {
                skill.ActualCd -= Time.deltaTime;
                if (skill.ActualCd < 0)
                {
                    skill.ActualCd = 0;
                }
            }
        }
    }

    private void InitSkillsDict()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].ActualCd = skills[i].Cooldown;
            skillsDict.Add(skills[i].Id, skills[i]);
        }
    }
}