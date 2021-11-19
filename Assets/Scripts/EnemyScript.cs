using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;

    private Transform target;
    private float speed = 3f;
    private Rigidbody body;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(target != null){
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }
        else if(other.gameObject.name == "DeathZone"){
            Destroy(gameObject);
        }
    }

    private void OnDisable() {
        if(gameObject.tag == "Enemy"){
        Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }
}
