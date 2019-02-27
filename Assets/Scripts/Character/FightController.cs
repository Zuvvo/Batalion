using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    [SerializeField]
    private List<SkillData> skills;

    public void InitAttackWithId(int id)
    {
        Debug.Log("Attack " + id);
    }

    private void Start()
    {
        STF.InputController.RegisterKeyAction(MyKeyCode.Attack1, true, () => InitAttackWithId(0));
        STF.InputController.RegisterKeyAction(MyKeyCode.Attack2, true, () => InitAttackWithId(1));
    }
}