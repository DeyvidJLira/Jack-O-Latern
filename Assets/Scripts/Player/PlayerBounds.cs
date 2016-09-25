using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour {

    private float m_MinX;
    private float m_MaxX;

	// Use this for initialization
	void Start () {
        SetMinAndMax();
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x < m_MinX) {
            Vector3 temp = transform.position;
            temp.x = m_MinX;
            transform.position = temp;
        }

        if(transform.position.x > m_MaxX) {
            Vector3 temp = transform.position;
            temp.x = m_MaxX;
            transform.position = temp;
        }
	}

    void SetMinAndMax() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        m_MaxX = bounds.x;
        m_MinX = -bounds.x;
    }
}
