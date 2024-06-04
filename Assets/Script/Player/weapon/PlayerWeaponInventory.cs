using UnityEngine;

public class PlayerWeaponInventory : MonoBehaviour
{

    private int CurrentWeapon = -1, BufferWeapon = -1;
    private float Timer;


    [SerializeField] ItemWeapon StartWeapon;

    HudWeaponMenu hudWeaponMenu;
    ItemWeapon []playerWeapon = new ItemWeapon[5];

    void Start()
    {
        hudWeaponMenu = transform.Find("Canvas").transform.Find("WeaponPanelBackground").transform.Find("WeaponPanel").GetComponent<HudWeaponMenu>();


        PlayerGiveWeapon(StartWeapon);
    }


    void Update()
    {
        if (!Input.anyKey)
            return;

        if (Input.GetKey(KeyCode.Alpha1)) ExecuteWeaponSlot(0);
        if (Input.GetKey(KeyCode.Alpha2)) ExecuteWeaponSlot(1);
        if (Input.GetKey(KeyCode.Alpha3)) ExecuteWeaponSlot(2);
        if (Input.GetKey(KeyCode.Alpha4)) ExecuteWeaponSlot(3);
        if (Input.GetKey(KeyCode.Alpha5)) ExecuteWeaponSlot(4);

        
        if (Input.GetKey(KeyCode.Q))
        {
            if (Timer < Time.time)
            {
                ExecuteWeaponLastSlot();
                Timer = Time.time + 0.2f;
            }
        }

        if (Input.GetKey(KeyCode.G))
        {
            if (GetWeaponCurrent() == 0)
                return;

            if (Timer < Time.time)
            {
                ExecuteWeaponDestroy(GetWeaponCurrent());
                Timer = Time.time + 0.35f;
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if (CurrentWeapon == -1)
                return; 

            if (Timer < Time.time)
            {
                GameObject _weapon;
                _weapon = Instantiate(playerWeapon[CurrentWeapon].obj);
                _weapon.transform.parent = transform.Find("Gun");
                Timer = Time.time + playerWeapon[CurrentWeapon].delay;
            }
        }
        
    }

    public void PlayerGiveWeapon(ItemWeapon item)
    {
        int slotItem = PlayerCheckWeaponInSlot(item);

        if (slotItem != -1)
        {
            playerWeapon[slotItem] = item; // Patrons
            return;
        }


        for (int i = 0; i < hudWeaponMenu.GetHudWeaponSlotSize(); i++)
        {
            if (hudWeaponMenu.IsHudWeaponActive(i) == false && item)
            {
                hudWeaponMenu.SetHudWeaponSlot(item, i);
                playerWeapon[i] = item;

                if (GetWeaponCurrent() == -1)
                {
                    ExecuteWeaponSlot(i);
                }
                break;
            }
        }
    }

    public void PlayerGiveWeapon(ItemWeapon item, int slot, bool choose)
    {
        if (slot < 0 || slot >= hudWeaponMenu.GetHudWeaponSlotSize() || !item)
            return;

        int slotItem = PlayerCheckWeaponInSlot(item);

        if (slotItem != -1)
        {
            if (slotItem != slot)
            {
                playerWeapon[slot] = playerWeapon[slotItem];
                hudWeaponMenu.SetHudWeaponSlot(item, slot);
                hudWeaponMenu.SetHudWeaponSlotDestroy(slotItem);
                playerWeapon[slotItem] = null;
            }
        } else
        {
            hudWeaponMenu.SetHudWeaponSlot(item, slot);
            playerWeapon[slot] = item;
        }


        if (choose)
             ExecuteWeaponSlot(slot);
    }

    public int PlayerCheckWeaponInSlot(ItemWeapon item)
    {
        for (int i = 0; i < hudWeaponMenu.GetHudWeaponSlotSize(); i++)
        {
            if (playerWeapon[i] == item)
                return i;
        }
        return -1;
    }

    public void ExecuteWeaponDestroy(int slot)
    {
        ExecuteWeaponLastSlot();
        hudWeaponMenu.SetHudWeaponSlotDestroy(slot);
        playerWeapon[slot] = null;
    }

    public void ExecuteWeaponSlot(int slot)
    {
        if (hudWeaponMenu.IsHudWeaponActive(slot) != false && CurrentWeapon != slot)
        {
            BufferWeapon = CurrentWeapon;
            CurrentWeapon = slot;

            hudWeaponMenu.SetHudWeaponActive(BufferWeapon, false);
            hudWeaponMenu.SetHudWeaponActive(CurrentWeapon, true);
        }    
    }

    public void ExecuteWeaponLastSlot()
    {
        ExecuteWeaponSlot(BufferWeapon);
    }
    
    public int GetWeaponCurrent()
    {
        return CurrentWeapon;
    }

    public ItemWeapon PlayerGetWeapon()
    {
        return playerWeapon[CurrentWeapon];
    }
}
