using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closed : StateMachineBehaviour {
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.ResetTrigger("Close");
    }
}
