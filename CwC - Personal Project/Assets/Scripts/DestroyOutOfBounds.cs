using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float boundX, boundZ, boundY;

    void Update()
    {
        if (transform.position.x > boundX || transform.position.x < -boundX ||
           transform.position.z > boundZ || transform.position.z < -boundZ ||
           transform.position.y > boundY || transform.position.y < 0)
            Destroy(gameObject);
    }
}
