using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    public Animator animator;
    public string currentState = "Idle";

    public void ChangeAnimationState(string newState){
        if(currentState == newState){
            return;
        }
        currentState = newState;
        animator.Play(newState);
    }
}
