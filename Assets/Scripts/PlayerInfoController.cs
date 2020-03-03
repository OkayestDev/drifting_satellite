using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInfoController : MonoBehaviour {
    // Update is called once per frame
    void Update () {
        Text points = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        points.text = GameSystem.points.ToString();

        Slider healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        healthBar.value = PlayerController.playerHealth;
    }
}
