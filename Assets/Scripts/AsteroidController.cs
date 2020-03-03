using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @TODO random rotation
public class AsteroidController : MonoBehaviour {
    private Rigidbody2D asteroidRb;
    private float randomZRotation;

    void Start () {
        this.randomZRotation = Random.Range(0f, 1.1f);
        this.asteroidRb = GetComponent<Rigidbody2D>();
        this.asteroidRb.velocity = new Vector3(-2, 0, 0);
    }

    // Check if Entity is in bounds, destroy if not
    void Update() {
        if (gameObject.transform.position.x < -4) {
            Destroy(gameObject);
            GameSystem.points += 10;
        }
        else {
            // @TODO decide if we want to keep this
            gameObject.transform.Rotate(0, 0, this.randomZRotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Instantiate(Resources.Load("Explosion"), gameObject.transform.position, new Quaternion());
            GameSystem.playAsteroidExplosion();
            CameraShake.shakeDuration = .5f;
            Destroy(gameObject);
        }
    }
}
