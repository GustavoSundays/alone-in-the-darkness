using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int health;

    [HideInInspector]
    public Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
