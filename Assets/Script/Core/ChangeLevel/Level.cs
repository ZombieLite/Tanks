using UnityEngine;

static public class Level
{
    private static GameObject _loading;
    private static Animator _animator;
    private static string LevelNext;

    static public void SetLevel(string LevelName)
    {
        LevelNext = LevelName;

       
        _loading = GameObject.Find("Core");

        if (_loading == null)
            return;

        _loading = _loading.transform.GetChild(0).gameObject;

        if (_loading == null)
            return;

        _loading.SetActive(true);

        _animator = _loading.GetComponentInChildren<Animator>();

        if (_animator == null)
            return;

        _animator.SetTrigger("FadeIn");
    }

    static public string GetLevel()
    {
        return LevelNext;
    }
}
