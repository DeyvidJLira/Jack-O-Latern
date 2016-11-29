using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager m_Instance;

    public int m_ScorePlayer { get; private set; }
    public int m_LifePlayer { get; private set; }
    public int m_CoinPlayer{ get; private set; }

    public enum GameState {
        GAMEPLAY,
        GAMEOVER
    }

    public GameState m_State { get; private set; }

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
        m_State = GameState.GAMEPLAY;
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
        m_State = GameState.GAMEPLAY;
    }

    public void GameOver() {
        m_State = GameState.GAMEOVER;
        PlayerScore playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        GameplayController.m_Instance.GameOver(playerScore.m_ScoreCount, playerScore.m_CoinCount);
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu() {
        yield return new WaitForSeconds(3f);
        SceneFaderController.m_Instance.LoadScene("MainMenu");
    }
}
