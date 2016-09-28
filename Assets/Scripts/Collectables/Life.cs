using UnityEngine;
using System.Collections;
using System;

public class Life : CollectableBase {

    [SerializeField]
    private int m_LifePoints = 1;
    [SerializeField]
    private int m_ScorePoints = 200;

    protected override void Effect(GameObject player) {
        PlayerScore playerScore = player.GetComponent<PlayerScore>();
        playerScore.IncreaseLife(m_LifePoints);
        playerScore.IncreaseScore(m_ScorePoints);
    }
}
