using System.Collections;
using UnityEngine;

public class FirstTankCore : MonoBehaviour
{
    [SerializeField] GameObject gunWeapon;
    [SerializeField] int health;
    [SerializeField] float speedAttack;

    private GameObject zoneRandom;
    private int _state;

    
    PlayerCore playerCore;
    RandomCore random;
    EnemyCore enemy;
    DamageCore damage;
    GameObject _victim;
    RaycastHit hit;
    Ray ray;

    public FriendlyFire friendlyFire = FriendlyFire.NonFrendly;

    private void Awake()
    {
        random = gameObject.AddComponent<RandomCore>();
        enemy = gameObject.AddComponent<EnemyCore>();
        enemy = gameObject.GetComponent<EnemyCore>();
        damage = gameObject.AddComponent<DamageCore>();

        zoneRandom = GameObject.Find("PlaneAI");

        enemy.SetEnemyHealth(gameObject, health);
        Spawn();    
    }

    private void Update()
    {
        switch (_state)
        {
            
            case 1:
                if(!enemy.EnemyMoveStart(gameObject, random.RandomPosition(zoneRandom, 5, 10)))
                    break;

                _state++;
                break;
            case 2:
                ray = new Ray(transform.position, transform.forward);
                Physics.Raycast(ray, out hit);

                if (hit.collider != null)
                {
                    if (friendlyFire == FriendlyFire.NonFrendly)
                    {
                        if (hit.collider.tag == "Player")
                        {
                            _state = 5;
                            //enemy.StopEnemyNav(gameObject);
                        }
                            
                    }
                    else
                    {
                        if (hit.collider.tag == "Enemy")
                        {
                            _state = 5;
                            //enemy.StopEnemyNav(gameObject);
                        }
                    }
                }

                if (!enemy.GetEnemyMove(gameObject))
                {
                    _state++;
                    break;
                }
                break;
            case 3:

                if (friendlyFire == FriendlyFire.NonFrendly)
                {
                    _victim = random.RandomPlayer();                    
                } else
                {
                    _victim = random.RandomEnemy();
                }

                if (_victim == gameObject)
                    break;

                if (_victim == null)
                    break;

                _state++;
                break;
            case 4:            
                if (_victim == null)
                {
                    _state--;
                    break;
                }

                GameObject target = enemy.EnemyRotation(gameObject, _victim.transform.position);

                if (target == null)
                {
                    break;
                }

                if (friendlyFire == FriendlyFire.NonFrendly)
                {
                    if (target.tag == "Player")
                        _state++;
                }
                else
                {
                    if (target.tag == "Enemy")
                        _state++;
                }
                break;
            case 5:
                Fire();
                StartCoroutine(EnemyCorutine());
                _state = 6;
                break;
        }
    }

    private void Spawn()
    {
        _state = 1;
    }

    private void Fire()
    {
        GameObject bullet;
        bullet = Instantiate(gunWeapon);
        bullet.transform.parent = transform.Find("Gun");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float dmg = collision.relativeVelocity.magnitude;

            damage.TakeDamage(gameObject, ((int)dmg));
        }

    }

    IEnumerator EnemyCorutine()
    {
        yield return new WaitForSeconds(1.0f);
        _state = 1;
    }

    public void EnemyFriendlyFire(FriendlyFire ff)
    {
        friendlyFire = ff;
    }
}
