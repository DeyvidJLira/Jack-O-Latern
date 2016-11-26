using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager m_Instance;

    public int m_ScorePlayer { get; private set; }
    public int m_LifePlayer { get; private set; }
    public int m_CoinPlayer{ get; private set; }

    void Awake() {
        if(m_Instance == null) {
            m_Instance = this;
            DontDestroyOnLoad(m_Instance);
        } else {
            Destroy(this);
        }
    }
   
    public void NewGame() {
        m_ScorePlayer = 0;
        m_LifePlayer = 2;
        m_CoinPlayer = 0;
        SceneFaderController.m_Instance.LoadScene("Gameplay");
    }

    public void Restart() {
        PlayerScore playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        m_ScorePlayer = playerScore.m_ScoreCount;
        m_LifePlayer = playerScore.m_LifeCount;
        m_CoinPlayer = playerScore.m_CoinCount;
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame() {
        yield return new WaitForSeconds(2f);
        SceneFaderController.m_Instance.LoadScene("Gameplay");
    }

    public void GameOver() {
        PlayerScore playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        GameplayController.m_Instance.GameOver(playerScore.m_ScoreCount, playerScore.m_CoinCount);
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu() {
        yield return new WaitForSeconds(3f);
        SceneFaderController.m_Instance.LoadScene("MainMenu");
    }

}
