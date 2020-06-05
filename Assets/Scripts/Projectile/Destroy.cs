using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : StateMachineBehaviour
{
    public float time;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, time);
    }
}
