using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimLoadingProgress : StateMachineBehaviour
{
    private GameObject _celbox, _txtMission;
    private AsyncOperation sceneAsync;
    private int _progress;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        _celbox = animator.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        _txtMission = animator.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;

        _txtMission.SetActive(true);




        sceneAsync = SceneManager.LoadSceneAsync(Level.GetLevel());
        sceneAsync.allowSceneActivation = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _progress = Mathf.RoundToInt(sceneAsync.progress * 22);

        for (int i = 0; i <= _progress; i++)
        {
            if (i > 20)
                continue;

            _celbox.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //CellClear();
    }

    private void CellClear()
    {
        for (int i = 0; i < _celbox.transform.childCount; i++)
        {
            _celbox.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
