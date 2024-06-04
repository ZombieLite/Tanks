using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] Image HpBar;
    [SerializeField] public Image HpBarSecond;

    private float CurretHp, LastHp;
    private float FillBuffer;

    private float Timer;

    private bool sStoping = false;

    PlayerCore player;
    
    private void Start()
    {
        player = transform.parent.transform.parent.GetComponent<PlayerCore>();

        if (player == null)
            return;

        CurretHp = (100.0f / player.GetPlayerHealth() * player.GetPlayerMaxHealth()) / 100.0f;
    }
    void FixedUpdate()
    {
        if (HpBar == null || player == null)
            return;

        if (player.GetPlayerHealth() <= 0.0)
        {
            this.gameObject.SetActive(false);
        }

        CurretHp = (100.0f / player.GetPlayerMaxHealth() * player.GetPlayerHealth()) / 100.0f;
        HpBar.fillAmount = CurretHp;

        if (CurretHp < LastHp)
            FillBuffer = HpBarSecond.fillAmount - HpBar.fillAmount;

        LastHp = CurretHp;

        if (HpBar.fillAmount > HpBarSecond.fillAmount)
            HpBarSecond.fillAmount = HpBar.fillAmount;
        else
        {
            if (FillBuffer > 0.0f)
            {
                if (!sStoping)
                {
                    Timer = Time.time + 0.5f;
                    sStoping = true;
                }

                if (Timer < Time.time)
                {
                    FillBuffer -= 0.005f;
                    HpBarSecond.fillAmount -= 0.005f;
                    Timer = Time.time + 0.0009f;
                }

            }
            else sStoping = false;
        }
    }
}
