using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour {
    
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shotPoint;
    [SerializeField] float timeBetweenShots;

    private float shotTime;

    void Update() {
        RotateWeapon();
    }

    void RotateWeapon() {
        Vector2 mousePosition = Mouse.current.position.ReadValue();   
        Vector2 direction = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }

    void OnFire(InputValue value) {
        if (Time.time >= shotTime) {
            Instantiate(projectile, shotPoint.position, transform.rotation);
            shotTime = Time.time + timeBetweenShots;
        }
    }
}
