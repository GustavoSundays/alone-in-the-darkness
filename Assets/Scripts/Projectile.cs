using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float lifeTime;
    [SerializeField] float speed;
    [SerializeField] int damage;


    void Start() {
        Invoke("DestroyProjectile", lifeTime);
    }

    void Update() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            other.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
