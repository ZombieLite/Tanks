using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private int enemyHealth;
    Rigidbody KnockBack;

    private void Start()
    {
        enemyHealth = Random.Range(100, 200);
    }

    // Update is called once per frame
    void Update()
    {
        //if (enemyHealth <= 0)
         //   Destroy(this.gameObject);
    }

    public void EnemyDamage(int a)
    {
        enemyHealth -= a;
    }

    public void EnemyDamage(int a, Vector3 vec, float knockback)
    {
        KnockBack = this.gameObject.GetComponent<Rigidbody>();
        KnockBack.AddForce(vec * 20000.0f, ForceMode.Impulse);
        StartCoroutine(StopKnockback());
        enemyHealth -= a;
    }

    IEnumerator StopKnockback()
    {
        yield return new WaitForSeconds(0.05f);
        KnockBack.isKinematic = true;
        KnockBack.isKinematic = false;
    }
}
