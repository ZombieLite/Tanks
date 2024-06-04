using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObject/ItemWeapon")]
public class ItemWeapon : ScriptableObject
{
    public int id;
    public Sprite icon;
    public int damage;
    public float delay = 1.0f;
    public float speed = 100.0f;
    public float knockback = 200.0f;

    [Space]
    public string className = "Item";
    public GameObject obj;
}
