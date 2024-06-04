#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public partial class SO_Scene_Container : ScriptableObject
{
    [SerializeField] SceneAsset Scene;

    /*
    private void OnValidate()
    {
        if (Scene == null)
            return;

        SO_Scene _scene = ScriptableObject.CreateInstance<SO_Scene>();
        _scene.name = Scene.name;
        _scene.Init(this);
        _soScene.Add(_scene);

        AssetDatabase.AddObjectToAsset(_scene, this);
        AssetDatabase.SaveAssets();

        EditorUtility.SetDirty(this);
        EditorUtility.SetDirty(_scene);
    }
    */
}
#endif