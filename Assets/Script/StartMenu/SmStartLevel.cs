using UnityEngine;

public class SmStartLevel : MonoBehaviour
{
    ChangeLevel _changeLevel;
    private void Start()
    {
        _changeLevel = this.GetComponent<ChangeLevel>();   
    }
    public void StartNextLevel()
    {
        Level.SetLevel(_changeLevel.LevelNext);
    }
}

