using UnityEngine;

public class nullFixedBug : MonoBehaviour
{
    public void test()
    {
        Debug.Log("Rabotaet");
    }
    public Vector3 _PlayerNullPosition()
    {
        return this.transform.position;
    }
}