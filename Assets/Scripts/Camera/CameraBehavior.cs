﻿using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    private float m_Speed = 1f;
    private float m_Acceleration = 0.2f;
    private float m_SpeedMax = 3.2f;

    private float m_EasySpeed = 3.4f;
    private float m_MediumSpeed = 3.8f;
    private float m_HardSpeed = 4.2f;

    [HideInInspector]
    public bool m_CanMoveCamera;

	// Use this for initialization
	void Start () {
        switch (GamePreferencesManager.m_Instance.m_LevelDifficulty) {
            case LevelDifficulty.EASY:
                m_SpeedMax = m_EasySpeed;
                break;
            case LevelDifficulty.MEDIUM:
                m_SpeedMax = m_MediumSpeed;
                break;
            case LevelDifficulty.HARD:
                m_SpeedMax = m_HardSpeed;
                break;
        }
        m_CanMoveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_CanMoveCamera)
            MoveCamera();
	}

    void MoveCamera() {
        Vector3 temp = transform.position;

        float oldY = temp.y;

        float newY = temp.y - (m_Speed * Time.deltaTime);

        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;

        m_Speed += m_Acceleration * Time.deltaTime;

        if (m_Speed > m_SpeedMax)
            m_Speed = m_SpeedMax;
    }
}
