using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmRotate : MonoBehaviour
{
    static float rotating = 0.0f;
    static float _timer;

    // Update is called once per frame
    void FixedUpdate()
    {
        rotating += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(0, rotating, 0);

    }
}
