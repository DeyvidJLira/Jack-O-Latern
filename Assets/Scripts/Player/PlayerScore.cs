using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    private AudioClip m_LifeSoundEffect;
    [SerializeField]
    private AudioClip m_CoinSoundEffect;    

    private CameraBehavior m_CameraBehavior;

    private Vector3 m_PreviousPosition;
    private bool m_CanCountScore;

    public static int m_ScoreCount = 0;
    public static int m_LifeCount;
    public static int m_CoinCount;

    void Awake() {
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
        if(target.tag == "Coin") {
            m_CoinCount++;
            m_ScoreCount += 100;

            AudioSource.PlayClipAtPoint(m_CoinSoundEffect, transform.position);
            target.gameObject.SetActive(false);
        }
        if(target.tag == "Life") {
            m_LifeCount++;
            m_ScoreCount += 200;

            AudioSource.PlayClipAtPoint(m_LifeSoundEffect, transform.position);
            target.gameObject.SetActive(false);
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
}
