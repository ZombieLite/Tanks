using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCore : MonoBehaviour
{
    public void TakeDamage(GameObject obj, int dmg)
    {
        if (obj == null)
            return;

        if (obj.tag == "Enemy")
        {
            EnemyCore enemy = obj.GetComponent<EnemyCore>();
            int Health, Damage;

            Health = enemy.GetEnemyHealth(obj);

            Damage = Health - dmg;

            enemy.SetEnemyHealth(obj, Damage);
            return;
        }
        if (obj.tag == "Player")
        {
            PlayerCore player = obj.GetComponent<PlayerCore>();
            int Health, Damage;

            Health = player.GetPlayerHealth();

            Damage = Health - dmg;

            player.SetPlayerHealth(Damage);
            return;
        }
    }
}
