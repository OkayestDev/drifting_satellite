using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All possible inputs
enum Inputs {none, left, right}

public class PlayerController : MonoBehaviour {
    public static int playerHealth = 1;
    private Rigidbody2D playerRigidbody;
    private Inputs previousInput = Inputs.none;

    void Start() {
        playerHealth = 1;
        this.playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Asteroids deal 1 damage?
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Contains("Asteroid")) {
            playerHealth = playerHealth - 1;
            if (playerHealth <= 0) {
                GameSystem.playPlayerDeath();
                Instantiate(Resources.Load("PlayerExplosion"), gameObject.transform.position, new Quaternion());
                GameSystem.gameOver();
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag.Contains("Heart")) {
            if (playerHealth < 3) {
                playerHealth++;
            }
        }
        else if (other.gameObject.tag.Contains("Coin")) {
            GameSystem.points += 50;
        }
    }

    void playerMovement() {
        // Mouse down === touch input
        if (Input.GetMouseButtonDown(0)) {
            Vector3 touchPosition = Input.mousePosition;
            // Left part of screen
            if (touchPosition[0] < Screen.width / 2) {
                this.playerRigidbody.velocity = new Vector2(-1, 3);
                this.previousInput = Inputs.left;
            }
            // Right part of screen
            else {
                this.playerRigidbody.velocity = new Vector2(1, 3);
                this.previousInput = Inputs.right;
            }
        }
    }

    void playerRotation() {
        switch (this.previousInput) {
            case Inputs.left:
                gameObject.transform.Rotate(new Vector3(0, 0, .5f));
                break;
            case Inputs.right:
                gameObject.transform.Rotate(new Vector3(0, 0, -.5f));
                break;
        }
    }

    void constrainPlayer() {
        Vector3 playerPosition = gameObject.transform.position;
        float xVelocity = 0f;
        float yVelocity = 0f;
        // Checking x
        if (playerPosition.x > 3) {
            xVelocity = -1f;
        }
        else if (playerPosition.x < -3) {
            xVelocity = 1f;
        }
        // Checking y
        if (playerPosition.y > 5) {
            yVelocity = -1f;
        }
        else if (playerPosition.y < -5) {
            yVelocity = 1f;
        }

        Vector2 reboundVelocity = new Vector2(xVelocity, yVelocity);
        this.playerRigidbody.velocity = playerRigidbody.velocity + reboundVelocity;
    }

    void Update() {
        this.playerMovement();
        this.playerRotation();
        this.constrainPlayer();
    }
}
