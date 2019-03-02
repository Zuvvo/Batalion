using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttacksDB", menuName = "DB/AttacksDB", order = 1)]
public class AttacksDB : ScriptableObject
{
    public List<AttackEffect> AttackEffectsPrefabs;

    public AttackEffect GetAttackEffectWithId(int id)
    {
        for (int i = 0; i < AttackEffectsPrefabs.Count; i++)
        {
            AttackEffect prefab = AttackEffectsPrefabs[i];
            if (prefab.Id == id)
            {
                return prefab;
            }
        }
        Debug.LogWarning("Can't find attack prefab with id " + id);
        return null;
    }
}