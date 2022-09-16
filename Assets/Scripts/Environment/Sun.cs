using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private Transform sun;
    private void Update()
    {
        var dir = transform.position - sun.position;
        transform.LookAt(dir);
    }
}
