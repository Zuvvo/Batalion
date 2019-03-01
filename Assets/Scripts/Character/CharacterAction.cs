using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public CharacterWork Work;
    public WorkType ActualWorkType;
    public Transform ProgressBarTransformPosition;

    private bool isEnabled = true;
    private Character character;

    private void Start()
    {
        character = STF.GameManager.Character;
        STF.UiManager.UiCharacterProgress.Init(transform);
    }

    public void StartRepairing(UranDiggerRepairing uranRepairing)
    {
        if (isEnabled)
        {
            ActualWorkType = WorkType.Repairing;
            int workTicks = (int)(uranRepairing.MaxHealth - uranRepairing.ActualHealth);
            Work.StartWork(character.Stats.RepairOneHealthTime, workTicks, () => StopRepairing(uranRepairing), () => uranRepairing.ChangeHealth(1));
        }
    }

    public void StopRepairing(UranDiggerRepairing uranRepairing)
    {
        Work.ForceStopWork();
        ActualWorkType = WorkType.None;
    }

    public void DisableWorking()
    {
        isEnabled = false;
        Work.ForceStopWork();
        ActualWorkType = WorkType.None;
    }

    public void EnableWorking()
    {
        isEnabled = true;
    }

    private void Update()
    {
        
    }
}