using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour {
    private Vector3 heartFallingSpeed = new Vector3(0, -1, 0);
    private Rigidbody2D heart;

    void Start() {
        this.heart = GetComponent<Rigidbody2D>();
        this.heart.velocity = this.heartFallingSpeed;
    }

    void Update() {
        if (gameObject.transform.position.y <= -6) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GameSystem.playHeartCollected();
            Destroy(gameObject);
        }
    }
}