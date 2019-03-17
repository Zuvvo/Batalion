using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    public AnimationState CurrentState = AnimationState.Idle;
    public Animator Animator;

    public void SetState(AnimationState state)
    {
        if(CurrentState != state)
        {
            Debug.Log("Changing anim state: " + state.ToString());
            CurrentState = state;
            Animator.SetInteger("AnimationState", (int)state);
        }
    }
}