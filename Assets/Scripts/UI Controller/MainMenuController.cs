using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void StartGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void Highscore() {
        SceneManager.LoadScene("Highscore");
    }

    public void Options() {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ButtonMusic() {

    }
}
