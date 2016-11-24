using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HighscoreController : MonoBehaviour {

    [SerializeField]
    private Text m_HighscoreText, m_CoinHighscoreText;

    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GameObject.Find("Canvas").GetComponent<Animator>();
        UpdateHighscore(); 
    }

    void Update() {
        if(GamePreferencesManager.m_Instance.m_Switched) {
            UpdateHighscore();
            GamePreferencesManager.m_Instance.m_Switched = false;
        }
    }

    void UpdateHighscore() {
        SetHighscore(GamePreferencesManager.m_Instance.m_Highscore, GamePreferencesManager.m_Instance.m_Coin_Highscore);
    }

    void SetHighscore(int highscore, int coinHighscore) {
        m_HighscoreText.text = highscore.ToString();
        m_CoinHighscoreText.text = coinHighscore.ToString();
    }
	
    public void BackToMainMenu() {
        animator.SetBool("IsCallHighScore", false);
        animator.SetTrigger("ExitHighscore");
    }
}
