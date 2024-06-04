using UnityEngine;
using UnityEngine.UI;

public class HudWeaponMenu : MonoBehaviour
{
    private string weaponActive;
    public void SetHudWeaponSlot(ItemWeapon weapon, int slot)
    {
        this.transform.GetChild(slot).gameObject.SetActive(true);
        this.transform.GetChild(slot).gameObject.GetComponent<Image>().sprite = weapon.icon;
        this.transform.GetChild(slot).gameObject.name = weapon.name;
        SetHudWeaponActive(slot, false);
    }

    public void SetHudWeaponSlotDestroy(int slot)
    {
        this.transform.GetChild(slot).gameObject.SetActive(false);
        this.transform.GetChild(slot).gameObject.name = null;
    }

    public bool IsHudWeaponActive(int slot)
    {
        if (slot < 0 || slot >= this.transform.childCount)
            return false;

        if (this.transform.GetChild(slot).gameObject.activeSelf)
            return true;
        else
            return false;
    }

    public void SetHudWeaponActive(int slot, bool active)
    {
        if (!IsHudWeaponActive(slot))
        {
            return;
        }

        if (!active)
        {
            this.transform.GetChild(slot).gameObject.GetComponent<ParticleSystem>().Stop();
            this.transform.GetChild(slot).gameObject.GetComponent<ParticleSystem>().Clear();
        }
        else
        {
            this.transform.GetChild(slot).gameObject.GetComponent<ParticleSystem>().Play();
            weaponActive = this.transform.GetChild(slot).gameObject.name;
        }
    }
    
    public int GetHudWeaponSlotSize()
    {
        return this.transform.childCount;
    }
    
    public string GetHudWeaponActiveSlotName()
    {  
        return weaponActive;
    }
}
