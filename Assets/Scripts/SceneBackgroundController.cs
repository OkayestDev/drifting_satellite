using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBackgroundController : MonoBehaviour {
    public static float spawnDelay = 0f;
    public static float spawnTime = .5f;

	void Start () {
		InvokeRepeating("spawnAsteroid", spawnDelay, spawnTime);
	}

	void spawnAsteroid() {
        int whichAsteroidToSpawn = Random.Range(1, 6);
        float spawnPointY = Random.Range(-4f, 4.5f);
        Vector3 spawnPoint = new Vector3(5, spawnPointY, 0);
        Instantiate(Resources.Load("Asteroid" + whichAsteroidToSpawn), spawnPoint, new Quaternion());
    }
}
