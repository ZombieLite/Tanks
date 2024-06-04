using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int speed;
    [SerializeField] int destroyTime;
    [SerializeField] int knockback;
    [SerializeField] GameObject spriteExplosion;

    DamageCore damageCore;
    void Start()
    {
        damageCore = gameObject.AddComponent<DamageCore>();
        damageCore = gameObject.GetComponent<DamageCore>();

        PrepareToFire();
        Fire();
        gameObject.transform.parent = null;
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

        gameObject.GetComponent<Rigidbody>().AddForce(vector * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == null)
             return;

        if (collision.gameObject.tag == "Wall")
        {
            GameObject ExplosionEnt = Instantiate(spriteExplosion, transform.position, transform.rotation);
            Destroy(ExplosionEnt, 3);
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * knockback, ForceMode.Acceleration);
            damageCore.TakeDamage(collision.gameObject, damage);

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
