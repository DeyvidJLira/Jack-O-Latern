using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    // Clouds
    [SerializeField]
    private GameObject[] m_Clouds;
	// Distance vertical between clouds
	private float m_DistanceBetweenClouds = 3f;
	// Minimum and maximum of the position horizontal
	private float m_MinX, m_MaxX;
	// Control position x to be generated
	private int m_ControlX = 0;
	// Position vertical of the last cloud
	private float m_LastCloudPositionY;
    // Player
    private GameObject m_Player;

	void Awake() {
		SetMinAndMaxX ();
        GenerateClouds();
    }

	// Use this for initialization
	void Start () {
		
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

	// Generate clouds
	void GenerateClouds() {
		Shuffle(m_Clouds);

		float positionY = 0f;

		for (int i = 0; i < m_Clouds.Length; i++) {
            Vector3 position = m_Clouds[i].transform.position;

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

            m_Clouds[i].transform.position = position;

			positionY -= m_DistanceBetweenClouds;
		}
	}

}
