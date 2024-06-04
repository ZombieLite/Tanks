using System.Collections;
using UnityEngine;

public class RandomCore : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    public Vector3 RandomPosition(GameObject zone, int sizeOffsets = 1, float sizeStuck = 3.0f)
    {
        if (zone == null)
            return Vector3.zero; 

        const float offsetsRndPos = 3.0f;
        
        Vector3 rndPosition = Vector3.zero;
        Vector3 sSize;

        ArrayList positionX = new ArrayList();
        ArrayList positionZ = new ArrayList();


        float spawnWidth, spawnHeight;

        spawnWidth = zone.transform.localScale.x;
        spawnHeight = zone.transform.localScale.z;

        spawnWidth = spawnWidth / 2 - offsetsRndPos;
        spawnHeight = spawnHeight / 2 - offsetsRndPos;

        float minX, maxX;
        float minZ, maxZ;

        minX = zone.transform.position.x - spawnWidth;
        maxX = zone.transform.position.x + spawnWidth;

        minZ = zone.transform.position.z - spawnHeight;
        maxZ = zone.transform.position.z + spawnHeight;

        for(int i = (int)minX; i < (int)maxX; i += sizeOffsets)
        {
            positionX.Add(i);
        }

        for (int i = (int)minZ; i < (int)maxZ; i += sizeOffsets)
        {
            positionZ.Add(i);
        }

        int posRndX, posRndZ;
        int posNum = positionX.Count + positionZ.Count;
        bool retEnt = false;

        sSize.x = sizeStuck;
        sSize.y = 0;
        sSize.z = sizeStuck;

        while (--posNum >= 0)
        {
            posRndX = (int)positionX[Random.Range(0, positionX.Count)];
            posRndZ = (int)positionZ[Random.Range(0, positionZ.Count)];
            rndPosition = new Vector3(posRndX, zone.transform.position.y, posRndZ);

            rndPosition.y += 1.1f;

            retEnt = Physics.CheckBox(rndPosition, sSize);
         

            if(!retEnt)
            {
                if (Terrain.activeTerrain.SampleHeight(rndPosition) <= 0)
                {
                    break;
                }
            }
        }
        
        if (posNum <= 0 && retEnt)
        {
            return Vector3.zero;
        }

        return rndPosition;
    }

    public GameObject RandomPlayer()
    {
        GameObject[] _objects = GameObject.FindGameObjectsWithTag("Player");

        if(_objects.Length == 0)
          return null;

        return _objects[Random.Range(0, _objects.Length)];
    }

    public GameObject RandomEnemy()
    {
        GameObject[] _objects = GameObject.FindGameObjectsWithTag("Enemy");

        if (_objects.Length == 0)
            return null;

        return _objects[Random.Range(0, _objects.Length)];
    }
}
