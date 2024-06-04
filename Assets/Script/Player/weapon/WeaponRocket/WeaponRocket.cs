using UnityEngine;

public class WeaponRocket : MonoBehaviour
{

    [SerializeField] ItemWeapon weaponSetting;
    [SerializeField] GameObject spriteExplosion;
    [SerializeField] int destroyTime;

    DamageCore damageCore;

    private void Start()
    {
        damageCore = gameObject.AddComponent<DamageCore>();
        
        PrepareToFire();
        Fire();
    }

    private void PrepareToFire()
    {
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
        Destroy(gameObject, destroyTime);
    }

    private void Fire()
    {
        Vector3 vector = transform.up.normalized;

        GetComponent<Rigidbody>().AddForce(vector * weaponSetting.speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Wall")
        {
            GameObject ExplosionEnt = Instantiate(spriteExplosion, transform.position, transform.rotation);
            Destroy(ExplosionEnt, 3);
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * weaponSetting.knockback, ForceMode.Acceleration);
            damageCore.TakeDamage(collision.gameObject, weaponSetting.damage);

            GameObject ExplosionEnt = Instantiate(spriteExplosion, transform.position, transform.rotation);
            Destroy(ExplosionEnt, 1);
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Weapon")
        {
            GameObject ExplosionEnt = Instantiate(spriteExplosion, transform.position, transform.rotation);
            Destroy(ExplosionEnt, 1);
            Destroy(gameObject);
        }


    }
       
}
