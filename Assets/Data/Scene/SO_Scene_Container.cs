using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneManager", menuName = "ScriptableObject/SceneManager")]
public partial class SO_Scene_Container : ScriptableObject
{
    [SerializeField] private List<SO_Scene> _soScene = new List<SO_Scene>();

    public List<SO_Scene> soScene { get => _soScene; set => _soScene = value; }
}
