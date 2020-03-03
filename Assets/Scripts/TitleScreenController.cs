using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class TitleScreenController : MonoBehaviour {
	private int highScore = 0;

	void Start () {
		if (PlayerPrefs.HasKey("HighScore")) {
			this.highScore = PlayerPrefs.GetInt("HighScore");
		}
		this.writeHighScoreAndAsteroidsAvoided();
		Canvas titleScreenCanvas = gameObject.GetComponent<Canvas>();
		titleScreenCanvas.worldCamera = Camera.main;
		Button playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();
		playButton.onClick.AddListener(onPlayClick);
		Button controlsButton = GameObject.FindGameObjectWithTag("ControlsButton").GetComponent<Button>();
		controlsButton.onClick.AddListener(onControlsClick);
		Button aboutButton = GameObject.FindGameObjectWithTag("AboutButton").GetComponent<Button>();
		aboutButton.onClick.AddListener(onAboutClick);

		AdMobController.initialize();
		AdMobController.requestBanner();
	}

	void writeHighScoreAndAsteroidsAvoided() {
		Text highScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
		highScoreText.text = "High Score: " + this.highScore;
	}

	void onPlayClick() {
		SceneManager.LoadScene("Game", LoadSceneMode.Single);
	}

	void onControlsClick() {
		SceneManager.LoadScene("Controls", LoadSceneMode.Single);
	}

	void onAboutClick() {
		SceneManager.LoadScene("About", LoadSceneMode.Single);
	}
}
