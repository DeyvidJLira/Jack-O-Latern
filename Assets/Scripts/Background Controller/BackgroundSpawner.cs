using UnityEngine;
using System.Collections;

public class BackgroundSpawner : MonoBehaviour {

    private GameObject[] m_Backgrounds;
    private float m_LastPositionY;

	// Use this for initialization
	void Start () {
        GetBackgroundAndSetLastY();
	}

    void GetBackgroundAndSetLastY() {
        m_Backgrounds = GameObject.FindGameObjectsWithTag("Background");

        m_LastPositionY = m_Backgrounds[0].transform.position.y;

        for(int i = 1; i < m_Backgrounds.Length; i++) {
            if (m_LastPositionY > m_Backgrounds[i].transform.position.y)
                m_LastPositionY = m_Backgrounds[i].transform.position.y;
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Background") {
            if(target.transform.position.y == m_LastPositionY) {
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;
                for(int i = 0; i < m_Backgrounds.Length; i++) {
                    if(!m_Backgrounds[i].activeInHierarchy) {
                        temp.y -= height;

                        m_LastPositionY = temp.y;

                        m_Backgrounds[i].transform.position = temp;
                        m_Backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
