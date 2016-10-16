using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    private Animator animator;

    void Start() {
        animator = GameObject.Find("Canvas").GetComponent<Animator>();
    }

	public void StartGame() {
        GameManager.m_Instance.NewGame();
    }

    public void Highscore() {
        animator.SetTrigger("ExitMenu");
        animator.SetBool("IsCallHighScore", true);
    }

    public void Options() {
        animator.SetTrigger("ExitMenu");
        animator.SetBool("IsCallOptions", true);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ButtonMusic() {

    }

}
