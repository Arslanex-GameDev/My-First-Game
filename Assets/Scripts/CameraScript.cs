using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform target;
    private Vector3 offsetVector;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Transform>();
        offsetVector = transform.position - target.position;
    }

    void Update()
    {
        if(target != null){
            transform.position = target.position + offsetVector;
            transform.LookAt(target.position);
        }
    }
}
