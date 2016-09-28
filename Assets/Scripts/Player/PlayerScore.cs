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
        m_ScoreCount = 0;
        m_LifeCount = 1;
        m_CoinCount = 0;
        m_CameraBehavior = Camera.main.GetComponent<CameraBehavior>();
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
                m_ScoreCount++;
            }
            m_PreviousPosition = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Collectable") {
            target.GetComponent<ICollectable>().Collected(gameObject);
        }

        if(target.tag == "Bound") {
            m_CameraBehavior.m_CanMoveCamera = false;
            m_CanCountScore = false;

            transform.position = new Vector3(500, 500, 0);
            m_LifeCount--;
        }

        if(target.tag == "DarkCloud") {
            m_CameraBehavior.m_CanMoveCamera = false;
            m_CanCountScore = false;

            transform.position = new Vector3(500, 500, 0);
            m_LifeCount--;
        }
    }

    public void IncreaseScore(int points) {
        m_ScoreCount += points;
    }

    public void IncreaseCoin(int points) {
        m_CoinCount += points;
    }

    public void DecreaseCoin(int points) {
        m_CoinCount -= points;
    }

    public void IncreaseLife(int points) {
        if (m_LifeCount < 2)
            m_LifeCount += points;
        if (m_LifeCount > 2)
            m_LifeCount = 2;
    }
}
