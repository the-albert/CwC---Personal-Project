﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCannonBall : MonoBehaviour
{
    public float ballSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * ballSpeed);
    }
}
