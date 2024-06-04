using UnityEngine;

public class AnimFadeOut : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.GetChild(0).transform.gameObject.SetActive(false);
    }
}
