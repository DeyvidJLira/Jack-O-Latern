using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    private CameraBehavior m_CameraBehavior;

    private Vector3 m_PreviousPosition;
    private bool m_CanCountScore;

    public int m_ScoreCount { get; private set; }
    public int m_LifeCount { get; private set; }
    public int m_CoinCount { get; private set; }

    void Awake() {
        m_CameraBehavior = Camera.main.GetComponent<CameraBehavior>();
    }

    void Initialize() {
        m_ScoreCount = 0;
        m_LifeCount = 1;
        m_CoinCount = 0;
        GameplayController.m_Instance.UpdateScoreText(m_ScoreCount);
        GameplayController.m_Instance.UpdateLifeText(m_LifeCount);
        GameplayController.m_Instance.UpdateCoinText(m_CoinCount);
    }

	// Use this for initialization
	void Start () {
        m_PreviousPosition = transform.position;
        m_CanCountScore = true;
	}
	
	// Update is called once per frame
	void Update () {
        IncreaseScore();
	}

    void IncreaseScore() {
        if(m_CanCountScore) {
            if(transform.position.y < m_PreviousPosition.y) {
                IncreaseScore(1);
            }
            m_PreviousPosition = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Collectable") {
            target.GetComponent<ICollectable>().Collected(gameObject);
        }

        if(target.tag == "Bound") {
            Died();
        }

        if(target.tag == "DarkCloud") {
            Died();
        }
    }

    public void Died() {
        m_CameraBehavior.m_CanMoveCamera = false;
        m_CanCountScore = false;

        transform.position = new Vector3(500, 500, 0);
        DecreaseLife();
    }

    public void IncreaseScore(int points) {
        m_ScoreCount += points;
        GameplayController.m_Instance.UpdateScoreText(m_ScoreCount);
    }

    public void IncreaseCoin(int points) {
        m_CoinCount += points;
        GameplayController.m_Instance.UpdateCoinText(m_CoinCount);
    }

    public void DecreaseCoin(int points) {
        m_CoinCount -= points;
        GameplayController.m_Instance.UpdateCoinText(m_CoinCount);
    }

    public void IncreaseLife(int points) {
        if (m_LifeCount < 2)
            m_LifeCount += points;
        if (m_LifeCount > 2)
            m_LifeCount = 2;
        GameplayController.m_Instance.UpdateLifeText(m_LifeCount);
    }

    public void DecreaseLife() {
        m_LifeCount--;
        GameplayController.m_Instance.UpdateLifeText(m_LifeCount);
    }
}
