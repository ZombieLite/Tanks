using UnityEngine;
using UnityEngine.AI;

public enum FriendlyFire
{
    NonFrendly,
    Frendly
};

public class EnemyCore : MonoBehaviour
{
    NavMeshAgent agent;
    NavMeshPath path;
    RaycastHit hit;
    Ray ray;

    private int health, maxHealth;

    public bool GetEnemyMove(GameObject index)
    {
        if (index == null)
            return false;

        agent = index.GetComponent<NavMeshAgent>();

        if (agent.remainingDistance <= agent.stoppingDistance)
            return false;

        return true;
    }
    
    public bool EnemyMoveStart(GameObject index, Vector3 position)
    {
        if (index == null || position == Vector3.zero)
            return false;

        path = new NavMeshPath();
        agent = index.GetComponent<NavMeshAgent>();

        agent.SetDestination(position);

        if (!agent.CalculatePath(position, path))
            return false;

        if (!agent.pathPending && !agent.hasPath)
            return false;

        if (agent.path.corners.Length <= 1)
            return false;

        switch (path.status)
        {
            case NavMeshPathStatus.PathComplete:
                return true;

            case NavMeshPathStatus.PathPartial: 

                /*
                 * Ближайшая точка
                 * 
                NavMeshHit hit;
                if (NavMesh.FindClosestEdge(position, out hit, NavMesh.AllAreas))
                {  
                    agent.SetDestination(hit.position);
                    Debug.DrawRay(hit.position, Vector3.up, Color.red);
                    return true;
                }
                */
                return false;
            case NavMeshPathStatus.PathInvalid:
                return false;
        }

        return false;
    }

    public GameObject EnemyRotation(GameObject index, Vector3 target)
    {
        if (index == null)
            return null;

        Vector3 direction = target - index.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction.normalized);
        rotation[2] = 0;
        rotation[0] = 0;

        index.transform.rotation = Quaternion.Lerp(index.transform.rotation, rotation, 2.0f * Time.deltaTime);

        ray = new Ray(index.transform.position, index.transform.forward);
        Physics.Raycast(ray, out hit);


        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }

        return null;
    }

    public void StopEnemyNav(GameObject index)
    {
        agent = index.GetComponent<NavMeshAgent>();
        agent.isStopped = true;
    }

    public void SetEnemyHealth(GameObject index, int hp)
    {
        if (health > maxHealth)
            maxHealth = health;

        if (hp <= 0)
        {
            health = 0;
            Destroy(this.gameObject);
            return;
        }

        health = hp;
    }

    public GameObject GetEnemyAlive(GameObject index)
    {
        if (GetEnemyHealth(index) <= 0)
            return null;

        return gameObject;
    }

    public int GetEnemyHealth(GameObject index)
    {
        return health;
    }

    public int GetEnemyMaxHealth(GameObject index)
    {
        return maxHealth;
    }
}
