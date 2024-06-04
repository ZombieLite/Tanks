using UnityEngine;

public class WeaponCore : MonoBehaviour
{
    public void GiveWeapon(GameObject index, ItemWeapon item)
    {
        if(index.tag == "Player")
        {
            PlayerWeaponInventory inventory = index.GetComponent<PlayerWeaponInventory>();
            inventory.PlayerGiveWeapon(item);
        }

    }
}
