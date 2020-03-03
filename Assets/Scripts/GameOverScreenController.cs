using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScreenController : MonoBehaviour {
    void Start() {
        // Setting GameOverScreen
        Canvas gameOverCanvas = gameObject.GetComponent<Canvas>();
        gameOverCanvas.worldCamera = Camera.main;
        // Setting points
        Text finalPoints = GameObject.FindGameObjectWithTag("FinalPoints").GetComponent<Text>();
        finalPoints.text = GameSystem.points.ToString();
        // Title Screen on click listener
        Button titleScreenButton = GameObject.FindGameObjectWithTag("TitleScreenButton").GetComponent<Button>();
        titleScreenButton.onClick.AddListener(onTitleScreenClick);
        // Play Again on click listener
        Button playAgainButton = GameObject.FindGameObjectWithTag("PlayAgainButton").GetComponent<Button>();
        playAgainButton.onClick.AddListener(onPlayAgainClick);
    }

    void onTitleScreenClick() {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    void onPlayAgainClick() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
