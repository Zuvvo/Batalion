using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AmmoDB", menuName = "DB/AmmoDB", order = 1)]
public class AmmoDB : ScriptableObject
{
    public List<EnemyAmmo> EnemyAmmoPrefabs;

    public EnemyAmmo GetEnemyAmmo(int id)
    {
        for (int i = 0; i < EnemyAmmoPrefabs.Count; i++)
        {
            if(EnemyAmmoPrefabs[i].Id == id)
            {
                return EnemyAmmoPrefabs[i];
            }
        }
        Debug.LogWarning("Can't find ammo with id " + id);
        return null;
    }
}