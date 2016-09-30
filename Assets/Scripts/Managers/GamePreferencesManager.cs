using UnityEngine;
using System.Collections;

public class GamePreferencesManager : MonoBehaviour {

    public static GamePreferencesManager m_Instance { get; private set; }

    public LevelDifficulty m_LevelDifficulty { get; private set; }
    public int m_Highscore { get; private set; }
    public int m_Coin_Highscore { get; private set; }

    private const string m_DIFFICULTY_EASY = "Difficulty_Easy";
    private const string m_DIFFICULTY_MEDIUM = "Difficulty_Medium";
    private const string m_DIFFICULTY_HARD = "Difficulty_Hard";

    private const string m_HIGHSCORE_EASY = "Highscore_Easy";
    private const string m_HIGHSCORE_MEDIUM = "Highscore_Medium";
    private const string m_HIGHSCORE_HARD = "Highscore_Hard";

    private const string m_COIN_HIGHSCORE_EASY = "Coin_Highscore_Easy";
    private const string m_COIN_HIGHSCORE_MEDIUM = "Coin_Highscore_Medium";
    private const string m_COIN_HIGHSCORE_HARD = "Coin_Highscore_Hard";

    void Awake() {
        if(m_Instance == null) {
            m_Instance = this;
            DontDestroyOnLoad(m_Instance);
        } else {
            Destroy(this);
        }

    }

    void Start() {
        m_LevelDifficulty = LevelDifficulty.MEDIUM;
        ConfigDifficulty(GetDifficultyPref());
    }

    public void ConfigDifficulty(LevelDifficulty levelDifficulty) {
        SetDifficultyPref(m_LevelDifficulty, 0);
        SetDifficultyPref(levelDifficulty, 1);
        m_LevelDifficulty = levelDifficulty;
        m_Highscore = GetHighscore();
        m_Coin_Highscore = GetCoinHighscore();
    }

    private void SetDifficultyPref(LevelDifficulty levelDifficulty, int value) {
        switch (levelDifficulty) {
            case LevelDifficulty.EASY:
                PlayerPrefs.SetInt(m_DIFFICULTY_EASY, value);
                break;
            case LevelDifficulty.MEDIUM:
                PlayerPrefs.SetInt(m_DIFFICULTY_MEDIUM, value);
                break;
            case LevelDifficulty.HARD:
                PlayerPrefs.SetInt(m_DIFFICULTY_HARD, value);
                break;
        }
    }

    private LevelDifficulty GetDifficultyPref() {
        if(PlayerPrefs.GetInt(m_DIFFICULTY_EASY, 0) == 1)
            return LevelDifficulty.EASY;
        if (PlayerPrefs.GetInt(m_DIFFICULTY_MEDIUM, 0) == 1)
            return LevelDifficulty.MEDIUM;
        if (PlayerPrefs.GetInt(m_DIFFICULTY_HARD, 0) == 1)
            return LevelDifficulty.HARD;
        return LevelDifficulty.MEDIUM;
    }

    public void SetHighscore(int score) {
        switch (m_LevelDifficulty) {
            case LevelDifficulty.EASY:
                if(score > m_Highscore)
                PlayerPrefs.SetInt(m_HIGHSCORE_EASY, score);
                break;
            case LevelDifficulty.MEDIUM:
                if (score > m_Highscore)
                    PlayerPrefs.SetInt(m_HIGHSCORE_MEDIUM, score);
                break;
            case LevelDifficulty.HARD:
                if (score > m_Highscore)
                    PlayerPrefs.SetInt(m_HIGHSCORE_HARD, score);
                break;
        }
    }

    private int GetHighscore() {
        switch (m_LevelDifficulty) {
            case LevelDifficulty.EASY:
                return PlayerPrefs.GetInt(m_HIGHSCORE_EASY, 0);
            case LevelDifficulty.MEDIUM:
                return PlayerPrefs.GetInt(m_HIGHSCORE_MEDIUM, 0);
            case LevelDifficulty.HARD:
                return PlayerPrefs.GetInt(m_HIGHSCORE_HARD, 0);
            default:
                return 0;
        }
    }

    public int GetHighscore(LevelDifficulty levelDifficulty) {
        switch (levelDifficulty) {
            case LevelDifficulty.EASY:
                return PlayerPrefs.GetInt(m_HIGHSCORE_EASY, 0);
            case LevelDifficulty.MEDIUM:
                return PlayerPrefs.GetInt(m_HIGHSCORE_MEDIUM, 0);
            case LevelDifficulty.HARD:
                return PlayerPrefs.GetInt(m_HIGHSCORE_HARD, 0);
            default:
                return 0;
        }
    }

    private int GetCoinHighscore() {
        switch (m_LevelDifficulty) {
            case LevelDifficulty.EASY:
                return PlayerPrefs.GetInt(m_COIN_HIGHSCORE_EASY, 0);
            case LevelDifficulty.MEDIUM:
                return PlayerPrefs.GetInt(m_COIN_HIGHSCORE_MEDIUM, 0);
            case LevelDifficulty.HARD:
                return PlayerPrefs.GetInt(m_COIN_HIGHSCORE_HARD, 0);
            default:
                return 0;
        }
    }

    public int GetCoinHighscore(LevelDifficulty levelDifficulty) {
        switch (levelDifficulty) {
            case LevelDifficulty.EASY:
                return PlayerPrefs.GetInt(m_COIN_HIGHSCORE_EASY, 0);
            case LevelDifficulty.MEDIUM:
                return PlayerPrefs.GetInt(m_COIN_HIGHSCORE_MEDIUM, 0);
            case LevelDifficulty.HARD:
                return PlayerPrefs.GetInt(m_COIN_HIGHSCORE_HARD, 0);
            default:
                return 0;
        }
    }

}

public enum LevelDifficulty {
    EASY,
    MEDIUM,
    HARD
}