using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HighscoreController : MonoBehaviour {

    [SerializeField]
    private Text m_HighscoreText, m_CoinHighscoreText;

    [SerializeField]
    private Animator _animator;

    // Use this for initialization
    void Start () {
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
        _animator.SetBool("IsCallHighScore", false);
        _animator.SetTrigger("ExitHighscore");
    }
}
