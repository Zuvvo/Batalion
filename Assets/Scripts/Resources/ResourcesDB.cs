using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttacksDB", menuName = "DB/AttacksDB", order = 1)]
public class ResourcesDB : ScriptableObject
{
    public List<Resource> AttackEffectsPrefabs;
}