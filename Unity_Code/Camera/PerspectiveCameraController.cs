using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveCameraController : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

        transform.LookAt(target.position);
    }
}
