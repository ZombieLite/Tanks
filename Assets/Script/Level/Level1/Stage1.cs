using UnityEngine;

public class Stage1 : MonoBehaviour
{
    [SerializeField] int enemyToComplete;
    [SerializeField] float spawnEnemyDelay;
    [SerializeField] Camera StartCamera;
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject FirstTank;
    float waitTime;
    int spawnEnemyDelayNum;

    private void Awake()
    {
        GameObject can;
        Camera cam;
       // cam = Instantiate(StartCamera);
       // cam.gameObject.SetActive(true);
       // can = Instantiate(StartCanvas);
       // can.GetComponent<Canvas>().worldCamera = cam;
    }

    void FixedUpdate()
    {
        if (spawnEnemyDelayNum < enemyToComplete)
        {
            if (waitTime <= Time.time)
            {
                spawnEnemyDelayNum++;
                Instantiate(FirstTank);
                waitTime = Time.time + spawnEnemyDelay;
            }
        }
    }
}
