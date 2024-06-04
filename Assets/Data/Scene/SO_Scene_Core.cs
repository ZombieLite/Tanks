#if UNITY_EDITOR
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEditor;

public partial class SO_Scene : ScriptableObject//, ISerializationCallbackReceiver
{
    public void Init(SO_Scene_Container scene)
    {
        _container = scene;
    }
}




/*
{
    public SceneAsset scene;
    private bool _isError = false;


    public void OnBeforeSerialize()
    {
        if (scene != null)
        {
            if (sceneName != scene.name)
            {
                sceneName = scene.name;
                EditorUtility.SetDirty(this);
                
                Core.SetTask(() => {
                    string szPath = AssetDatabase.GetAssetPath(this);

                    Debug.Log("-----------");
                    AssetNameAlready(sceneName, szPath);

                    AssetDatabase.RenameAsset(szPath, sceneName);
                }, 0.25f).Forget();
               
            }
            _isError = false;
        } 
        else
        {
            if(!_isError)
            {
                sceneName = string.Empty;
                Debug.LogError("[ERROR] В SO " + this.name + " отсутсвует сцена!");
                _isError = true;
            }    
        }
    }
    public void OnAfterDeserialize()
    {

    } 
    
    private bool AssetNameAlready(string Name, string Path)
    {
        string[] _szFolder = AssetDatabase.GetSubFolders(Path);
        //Debug.Log("FOLDER:" + _szFolder);
        
        //string[] _szResult = AssetDatabase.FindAssets(Name, new[] { _szFolder });

       // Debug.Log("SIZE:"+ _szResult.Length);
        
        foreach (string guid2 in _szFolder)
        {
            Debug.Log("Material: " + AssetDatabase.GUIDToAssetPath(guid2));
        }
        

        return false;
    }
}
*/
#endif
