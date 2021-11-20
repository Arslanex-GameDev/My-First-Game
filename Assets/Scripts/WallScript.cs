using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private float counter;
    private string nameOf;
    private Color color1;
    private float jumpForce = 5f;

    void Start()
    {
        color1 = GetComponent<MeshRenderer>().material.color;
    }

    void Update()
    {
        if(Time.time-counter > 3f){
            GetComponent<MeshRenderer>().material.color = color1;
        }
    }

    private void OnCollisionEnter(Collision other) {
        nameOf = other.gameObject.tag;
        if(nameOf == "Player"){
            GetComponent<MeshRenderer>().material.color = Color.black;
            counter = Time.timeSinceLevelLoad;
        }
        if(nameOf == "Enemy"){
            Rigidbody rb = other.collider.GetComponent<Rigidbody>();
            if(rb != null){
                Vector3 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
