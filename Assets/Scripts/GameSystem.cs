using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {
    public static bool isGameOverScreenShowing = false;
    public static bool isGameOver = false;
    private int framesPlayed = 0;
    private int heartsSpawned = 0;
    static AudioSource[] audioSources;
    public static int points = 0;
    public static float spawnDelay = 1.5f;
    public static float spawnTime = .4f;

    void Start() {
        audioSources = gameObject.GetComponents<AudioSource>();
        this.framesPlayed = 0;
        this.heartsSpawned = 0;
        if (!PlayerPrefs.HasKey("HighScore")) {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        this.startGame();
    }

    void Update() {
        if (!isGameOver) {
            this.spawnCoin();
            if (Math.Floor((double) points / 500) > this.heartsSpawned) {
                this.spawnHeart();
                this.heartsSpawned++;
            }
        }
        else {
            if (!isGameOverScreenShowing) {
                Invoke("showGameOverScreen", .8f);
                isGameOverScreenShowing = true;
            }
        }
        this.framesPlayed++;
    }

    void showGameOverScreen() {
        Canvas playerInfo = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<Canvas>();
        Destroy(playerInfo);
        Instantiate(Resources.Load("GameOverScreen"), new Vector3(0, 0, 0), new Quaternion());
    }

    public static void gameOver() {
        isGameOver = true;
        int previousHighScore = PlayerPrefs.GetInt("HighScore");
        if (points > previousHighScore) {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }

    public void startGame() {
        // Spawn and set Player's position to the initial one
        isGameOverScreenShowing = false;
        isGameOver = false;
        points = 0;
        CancelInvoke();
        GameObject doesPlayerExist = GameObject.FindGameObjectWithTag("Player");
        if (doesPlayerExist != null) {
            Destroy(doesPlayerExist);
        }
        Instantiate(Resources.Load("Player"), new Vector3(0, 3, 0), new Quaternion());
        InvokeRepeating("spawnAsteroid", spawnDelay, spawnTime);
    }

    void spawnAsteroid() {
        int whichAsteroidToSpawn = UnityEngine.Random.Range(1, 6);
        float spawnPointY = UnityEngine.Random.Range(-4f, 4.5f);
        Vector3 spawnPoint = new Vector3(5, spawnPointY, 0);
        Instantiate(Resources.Load("Asteroid" + whichAsteroidToSpawn), spawnPoint, new Quaternion());
    }

    // We spawn a heart every 500 points;
    void spawnHeart() {
        float spawnPointX = UnityEngine.Random.Range(-3f, 3f);
        Vector3 spawnPoint = new Vector3(spawnPointX, 6, 0);
        Instantiate(Resources.Load("Heart"), spawnPoint, new Quaternion());
    }

    void spawnCoin() {
        float chanceToSpawn = UnityEngine.Random.Range(0f, 10000f);
        if (chanceToSpawn < 10f) {
            float spawnPointX = UnityEngine.Random.Range(-3f, 3f);
            Vector3 spawnPoint = new Vector3(spawnPointX, 6, 0);
            Instantiate(Resources.Load("Coin"), spawnPoint, new Quaternion());
        }
    }

    public static void playAsteroidExplosion() {
        audioSources[0].Play();
    }

    public static void playPlayerDeath() {
        audioSources[1].Play();
    }

    public static void playCoinCollected() {
        audioSources[2].Play();
    }

    public static void playHeartCollected() {
        audioSources[3].Play();
    }
}
