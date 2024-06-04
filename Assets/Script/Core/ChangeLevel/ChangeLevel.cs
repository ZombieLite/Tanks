using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
#if UNITY_EDITOR
    public SceneAsset scene;
#endif
    public string LevelNext;

    /*
private AsyncOperation sceneAsync;
private GameObject _loading;
private Animator _animator;


private void Awake()
{
    _loading = GameObject.Find("ChangeLevel");

    if (_loading == null)
        return;

    _loading.SetActive(true);
    _animator = _loading.GetComponentInChildren<Animator>();

    if (_animator == null)
        return;

    _animator.SetTrigger("FadeOut");
}

public void StartNextlevel()
{
    if (LevelNext == "")
    {
        Debug.LogError("[ERROR] Невозможно поменять сцену. Сцена не выбрана!");
        return;
    }

    sceneAsync = SceneManager.LoadSceneAsync(LevelNext);
    sceneAsync.allowSceneActivation = false;

    _animator.SetTrigger("FadeIn");
}
*/
}

