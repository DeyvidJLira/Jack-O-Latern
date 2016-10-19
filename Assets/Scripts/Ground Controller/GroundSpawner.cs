using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {

    // Grounds
    [SerializeField]
    private GameObject[] m_Grounds;
	// Distance vertical between grounds
	private float m_DistanceBetweenGrounds = 3f;
	// Minimum and maximum of the position horizontal
	private float m_MinX, m_MaxX;
    // Control position x to be generated
    private int m_ControlX;
	// Position vertical of the last ground
	private float m_LastCloudPositionY;
    // Collectable items
    [SerializeField]
    private GameObject[] m_Collectables;
    // Player
    private GameObject m_Player;
    // Player Score
    private PlayerScore m_PlayerScore;

	void Awake() {
        m_ControlX = 0;
		SetMinAndMaxX ();
        GenerateGrounds();
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_PlayerScore = m_Player.GetComponent<PlayerScore>();

        for(int i = 0; i < m_Collectables.Length; i++) {
            m_Collectables[i].SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
        PositionThePlayer();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Configure bound horizontal
	void SetMinAndMaxX() {
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0));

		m_MaxX = bounds.x - 0.5f;
		m_MinX = -bounds.x + 0.5f;
	}

	// Shuffle a array of the game object and return array generated
	void Shuffle(GameObject[] arrayToShuffle) {
        for (int i = 0; i < arrayToShuffle.Length; i++) {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
	}

	// Generate grounds
	void GenerateGrounds() {
		Shuffle(m_Grounds);

		float positionY = 0f;

		for (int i = 0; i < m_Grounds.Length; i++) {
            Vector3 position = m_Grounds[i].transform.position;

			position.y = positionY;

			if (m_ControlX == 0) {
				position.x = Random.Range (0.0f, m_MaxX);
				m_ControlX = 1;
			} else if (m_ControlX == 1) {
				position.x = Random.Range (0.0f, m_MinX);
				m_ControlX = 2;
			} else if (m_ControlX == 2) {
				position.x = Random.Range (1.0f, m_MaxX);
				m_ControlX = 3;
			} else if (m_ControlX == 3) {
				position.x = Random.Range (-1.0f, m_MinX);
				m_ControlX = 1;
			}

			m_LastCloudPositionY = position.y;

            m_Grounds[i].transform.position = position;

			positionY -= m_DistanceBetweenGrounds;
		}
	}

    // Position the player in the first cloud
    void PositionThePlayer() {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("DarkCloud");
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        
        for(int i = 0; i < darkClouds.Length; i++) {
            if(darkClouds[i].transform.position.y == 0f) {
                Vector3 tempDarkCloudPosition = darkClouds[i].transform.position;
                darkClouds[i].transform.position = grounds[0].transform.position;
                grounds[0].transform.position = tempDarkCloudPosition;
            }
        }

        Vector3 temp = grounds[0].transform.position;

        for(int i = 1; i < grounds.Length; i++) {
            if (temp.y < grounds[i].transform.position.y) {
                temp = grounds[i].transform.position;
            }
        }

        temp.y += 0.8f;

        m_Player.transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Ground" || target.tag == "DarkCloud") {
            if(target.transform.position.y == m_LastCloudPositionY) {
                Shuffle(m_Grounds);

                Vector3 position = target.transform.position;

                for(int i = 0; i < m_Grounds.Length; i++) {
                    if(!m_Grounds[i].activeInHierarchy) {
                        if (m_ControlX == 0) {
                            position.x = Random.Range(0.0f, m_MaxX);
                            m_ControlX = 1;
                        } else if (m_ControlX == 1) {
                            position.x = Random.Range(0.0f, m_MinX);
                            m_ControlX = 2;
                        } else if (m_ControlX == 2) {
                            position.x = Random.Range(1.0f, m_MaxX);
                            m_ControlX = 3;
                        } else if (m_ControlX == 3) {
                            position.x = Random.Range(-1.0f, m_MinX);
                            m_ControlX = 1;
                        }

                        position.y -= m_DistanceBetweenGrounds;

                        m_LastCloudPositionY = position.y;

                        m_Grounds[i].transform.position = position;
                        m_Grounds[i].SetActive(true);

                        int random = Random.Range(0, m_Collectables.Length);

                        if (m_Grounds[i].tag != "DarkCloud") {
                            if(!m_Collectables[random].activeInHierarchy) {
                                Vector3 temp = m_Grounds[i].transform.position;
                                temp.y += 0.7f;

                                if(m_Collectables[random].tag == "Life") {
                                    if(m_PlayerScore.m_LifeCount < 2) {
                                        m_Collectables[random].transform.position = temp;
                                        m_Collectables[random].SetActive(true);
                                    }
                                } else {
                                    m_Collectables[random].transform.position = temp;
                                    m_Collectables[random].SetActive(true);
                                }
                            }
                        }
                    }
                }

                 
            }
        }
    }
}
