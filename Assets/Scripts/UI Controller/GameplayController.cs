using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayController : MonoBehaviour {

    public static GameplayController m_Instance;

    [SerializeField]
    private Text m_LifeText, m_CoinText, m_ScoreText;

    [SerializeField]
    private GameObject m_PanelPause; 

    void Awake() {
        if(m_Instance == null) {
            m_Instance = this;
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

}
