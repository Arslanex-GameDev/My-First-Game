using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int speed = 400;
    [SerializeField] private GameObject deathEffect;

    public bool gameOver = false;
    private Vector3 movement;
    private Rigidbody body;

    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float z = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        movement = new Vector3(x, 0f, z);
        body.AddForce(movement);

        if(gameOver == true)
            Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            gameOver = true;
        }
        else if(other.gameObject.name == "DeathZone"){
            gameOver = true;
        }
    }

    private void OnDisable() {
        Instantiate(deathEffect, transform.position, transform.rotation);
    }
}
