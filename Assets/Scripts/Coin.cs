using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{   
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject tokenDeathEffect;

    private float x = 1f;
    private float y = 0;
    private float z = 1f;

    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(x,y,z);
        if(gameObject.tag == "Token"){
            x=2;
            y=2;
            z=2;
            transform.Rotate(x,y,z,Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
        LevelManager levelManager = FindObjectOfType<LevelManager>();      
        levelManager.score += 1;
        print(levelManager.score); 
        Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
       if(other.gameObject.tag == "Player"){
           LevelManager levelManager = FindObjectOfType<LevelManager>();
           if(gameObject.tag == "Token"){
               levelManager.tokenScore += 1;
               Destroy(gameObject);
           }
           else if(gameObject.tag == "jCoin"){
               levelManager.score += 2;
               print(levelManager.score);
               Destroy(gameObject);
           }
       } 
       else if(other.gameObject.name == "DeathZone"){
           Destroy(gameObject);
       }
    }
    private void OnDisable() {
        if(gameObject.tag == "Coin" || gameObject.tag == "jCoin"){
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        else if(gameObject.tag == "Token"){
            Instantiate(tokenDeathEffect, transform.position, transform.rotation);
        }
    }
}