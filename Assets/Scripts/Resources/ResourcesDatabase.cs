using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourcesDB", menuName = "DB/ResourcesDB", order = 1)]
public class ResourcesDatabase : ScriptableObject
{
    public List<Resource> Resources;
}