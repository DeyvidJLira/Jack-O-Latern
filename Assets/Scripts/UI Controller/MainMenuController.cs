using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	
	public void StartGame() {
        GameManager.m_Instance.NewGame();
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
