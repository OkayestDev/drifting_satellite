using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    private Vector3 coinFallingSpeed = new Vector3(0, -.5f, 0);
    private Rigidbody2D coin;

    void Start() {
        this.coin = GetComponent<Rigidbody2D>();
        this.coin.velocity = this.coinFallingSpeed;
    }

    void Update() {
        if (gameObject.transform.position.y <= -6) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GameSystem.playCoinCollected();
            Destroy(gameObject);
        }
    }
}