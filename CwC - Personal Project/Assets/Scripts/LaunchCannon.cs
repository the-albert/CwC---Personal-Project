using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCannon : MonoBehaviour
{
    public GameObject cannonBall;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(cannonBall, transform.position, transform.rotation);
        }
    }
}
