using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button m_MusicButton;

    [SerializeField]
    private Sprite[] m_MusicIcons;

    private Animator animator;

    void Start() {
        animator = GameObject.Find("Canvas").GetComponent<Animator>();
        CheckToPlayMusic();
    }

    void CheckToPlayMusic() {
        if(GamePreferencesManager.m_Instance.GetMusicState() == MusicState.STOPPED) {
            MusicController.m_Instance.PlayMusic(true);
            m_MusicButton.image.sprite = m_MusicIcons[1];
        } else {
            MusicController.m_Instance.PlayMusic(false);
            m_MusicButton.image.sprite = m_MusicIcons[0];
        }
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
        if(GamePreferencesManager.m_Instance.GetMusicState() == MusicState.STOPPED) {
            GamePreferencesManager.m_Instance.SetMusicState(MusicState.PLAYING);
            MusicController.m_Instance.PlayMusic(true);
            m_MusicButton.image.sprite = m_MusicIcons[1];        
        } else {
            GamePreferencesManager.m_Instance.SetMusicState(MusicState.STOPPED);
            MusicController.m_Instance.PlayMusic(false);
            m_MusicButton.image.sprite = m_MusicIcons[0];
        }
    }

}
