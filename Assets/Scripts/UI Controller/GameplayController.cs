using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayController : MonoBehaviour {

    public static GameplayController m_Instance;

    [SerializeField]
    private Button m_ButtonReady;

    [SerializeField]
    private Text m_LifeText, m_CoinText, m_ScoreText, m_GameOverScoreText, m_GameOverCoinText;

    [SerializeField]
    private GameObject m_PanelPause, m_PanelGameOver; 

    void Awake() {
        if(m_Instance == null) {
            m_Instance = this;
            Time.timeScale = 0f;
        } else {
            Destroy(this);
        }
    }

    public void UpdateLifeText(int newValue) {
        m_LifeText.text = "x" + newValue;
    }

    public void UpdateCoinText(int newValue) {
        m_CoinText.text = "x" + newValue;
    }

    public void UpdateScoreText(int newValue) {
        m_ScoreText.text = "" + newValue;
    }

    public void StartGame() {
        m_ButtonReady.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        m_PanelPause.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        m_PanelPause.SetActive(false);
    }

    public void QuitGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(int finalScore, int finalCoinScore) {
        m_PanelGameOver.SetActive(true);
        m_GameOverScoreText.text = finalScore.ToString();
        m_GameOverCoinText.text = finalCoinScore.ToString();
    }

}
