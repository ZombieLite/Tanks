using UnityEngine;

public class SmSpawn : MonoBehaviour
{
    [SerializeField] GameObject tank;
    [SerializeField] GameObject zoneRandom;
    RandomCore random;

    private void Start()
    {
        gameObject.AddComponent<RandomCore>();
        random = gameObject.GetComponent<RandomCore>();
    }

    private void Update()
    {
        GameObject[] _objects = GameObject.FindGameObjectsWithTag("Enemy");

        if (_objects.Length > 20)
            return;

        Vector3 pos = random.RandomPosition(zoneRandom, 3, 10);

        if (pos == Vector3.zero)
        {
            return;
        }
        GameObject ent = Instantiate(tank, pos, transform.rotation);
        ent.GetComponent<FirstTankCore>().EnemyFriendlyFire(FriendlyFire.Frendly);
    }
}
