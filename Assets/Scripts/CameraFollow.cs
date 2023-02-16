using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] Transform playerTranform;
    [SerializeField] float speed;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    void Start() {
        transform.position = new Vector3(playerTranform.position.x, playerTranform.position.y, -1);
    }

    void Update() {
        if (playerTranform != null) {

            float clampedX = Mathf.Clamp(playerTranform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTranform.position.y, minY, maxY);

            transform.position = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, -1), speed);
        }
    }
}
