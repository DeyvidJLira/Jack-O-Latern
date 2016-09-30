using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HighscoreController : MonoBehaviour {

    [SerializeField]
    private Text m_HighscoreText, m_CoinHighscoreText;

	// Use this for initialization
	void Start () {
        SetHighscore(GamePreferencesManager.m_Instance.m_Highscore, GamePreferencesManager.m_Instance.m_Coin_Highscore);
    }

    void SetHighscore(int highscore, int coinHighscore) {
        m_HighscoreText.text = highscore.ToString();
        m_CoinHighscoreText.text = coinHighscore.ToString();
    }
	
    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
