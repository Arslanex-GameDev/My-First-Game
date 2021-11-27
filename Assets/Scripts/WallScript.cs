using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour

{    
    [SerializeField] private Material newMaterial;

    private Material currentMaterial;
    private float counter;
    private string nameOf;
    private float jumpForce = 5f;

    void Start()
    {
        currentMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if(Time.time-counter > 3f){
            GetComponent<MeshRenderer>().material = currentMaterial;
        }
    }

    private void OnCollisionEnter(Collision other) {
        nameOf = other.gameObject.tag;
        if(nameOf == "Player"){
            GetComponent<MeshRenderer>().material = newMaterial;
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
