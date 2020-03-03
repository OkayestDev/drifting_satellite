using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AboutScreenController : MonoBehaviour {
	void Start () {
		Button titleScreenButton = GameObject.FindGameObjectWithTag("TitleScreenButton").GetComponent<Button>();
		titleScreenButton.onClick.AddListener(onTitleScreenClick);
	}

	void onTitleScreenClick() {
		SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
	}
}
