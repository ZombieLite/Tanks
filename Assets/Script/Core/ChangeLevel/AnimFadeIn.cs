using UnityEngine;

public class AnimFadeIn : StateMachineBehaviour
{
    private GameObject _celbox;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.GetChild(0).transform.gameObject.SetActive(true);
        _celbox = animator.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

        CellClears();
    }

    private void CellClears()
    {
        for (int i = 0; i < _celbox.transform.childCount; i++)
        {
            _celbox.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
