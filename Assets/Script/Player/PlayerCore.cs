using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] int Health;
    private int MaxHealth;
    
    DamageCore damageCore;

    void Start()
    {
        Screen.SetResolution(1000, 600, false);

        damageCore = gameObject.AddComponent<DamageCore>();
        damageCore = gameObject.GetComponent<DamageCore>();

        MaxHealth = Health;
        Core.SetPlayerAliveCount(Core.GetPlayerAliveCount() + 1);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "Wall")
        {
            float damage = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            damage = damage / 2;

            damageCore.TakeDamage(gameObject, (int)damage);
        }

        
        if (collision.gameObject.tag == "Enemy")
        {
            float damage = collision.relativeVelocity.magnitude;

            damageCore.TakeDamage(gameObject, ((int)damage - 2));
        }

     }

    public GameObject GetPlayerAlive()
    {
        if (GetPlayerHealth() <= 0)
            return null;

        return gameObject;
    }

    public int GetPlayerHealth()
    {
        return Health;
    }

    public int GetPlayerMaxHealth()
    {
        return MaxHealth;
    }

    public void SetPlayerHealth(int health)
    {
        if (health > MaxHealth)
            MaxHealth = health;

        if(health <= 0)
        {
            Health = 0;
            Core.SetPlayerAliveCount(Core.GetPlayerAliveCount() - 1);
            Destroy(this.gameObject);
            return;
        }

        Health = health;
    }

    public void SetPlayerMaxHealth(int maxHealth)
    {
        if(maxHealth < Health)
            Health = maxHealth;

        MaxHealth = maxHealth;
    }

    public Vector3 GetPlayerPosition()
    {
        if (!GetPlayerAlive())
            return Vector3.zero;

        return transform.position;
    }
}
