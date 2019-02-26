using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private List<Cutscene> cutscenes;

    public void PlayCutscene(int id)
    {
        STF.GameManager.Character.MovementController.SetMovementActive(false);
        GetCutsceneWithId(id).Play();
    }

    private Cutscene GetCutsceneWithId(int id)
    {
        for (int i = 0; i < cutscenes.Count; i++)
        {
            if(cutscenes[i].Id == id)
            {
                return cutscenes[i];
            }
        }
        Debug.LogWarning("Can't find cutscene with id " + id);
        return null;
    }
}