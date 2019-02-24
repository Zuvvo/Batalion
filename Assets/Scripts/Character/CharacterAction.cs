using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public Character Character;
    public CharacterWork Work;
    public WorkType ActualWorkType;

    public Transform ProgressBarTransformPosition;

    private void Start()
    {
        STF.UiManager.UiCharacterProgress.Init(transform);
    }

    public void StartRepairing(UranDiggerRepairing uranRepairing)
    {
        ActualWorkType = WorkType.Repairing;
        int workTicks = (int)(uranRepairing.MaxHealth - uranRepairing.ActualHealth);
        Work.StartWork(Character.Stats.RepairOneHealthTime, workTicks, () => StopRepairing(uranRepairing), () => uranRepairing.ChangeHealth(1));
        
    }

    public void StopRepairing(UranDiggerRepairing uranRepairing)
    {
        Work.ForceStopWork();
        ActualWorkType = WorkType.None;
    }

    private void Update()
    {
        
    }
}