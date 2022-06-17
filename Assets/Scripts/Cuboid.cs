using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cuboid : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}
