using UnityEngine;
using System.Collections;

public class Coin : CollectableBase {

    [SerializeField]
    private int m_CoinPoints = 1;
    [SerializeField]
    private int m_ScorePoints = 100;

    protected override void Effect(GameObject player) {
        PlayerScore playerScore = player.GetComponent<PlayerScore>();
        playerScore.IncreaseCoin(m_CoinPoints);
        playerScore.IncreaseScore(m_ScorePoints);
    }
}
