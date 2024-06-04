using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;


[CustomEditor(typeof(ChangeLevel))]
public class ChangeLevelEditor : Editor
{
    ChangeLevel level;

    private void OnEnable()
    {

        if (level == null)
            level = this.target as ChangeLevel;

    }
    public override void OnInspectorGUI()
    {


        level.scene = (SceneAsset)EditorGUILayout.ObjectField("Выберите сцену:", level.scene, typeof(SceneAsset), false);

        if (level.scene == null)
        {
            level.LevelNext = null;
            EditorGUILayout.HelpBox("Сцена не выбрана!", MessageType.Warning);
        }
        else
        {
            level.LevelNext = level.scene.name;
            EditorGUILayout.HelpBox($"Ваша сцена: {level.LevelNext}", MessageType.Info);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(level);
            EditorSceneManager.MarkSceneDirty(level.gameObject.scene);
            serializedObject.ApplyModifiedProperties();
        }    
    }
}
#endif


