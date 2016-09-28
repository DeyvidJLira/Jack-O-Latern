using UnityEngine;
using System.Collections;

public abstract class CollectableBase : MonoBehaviour, ICollectable {
    [SerializeField]
    protected AudioClip m_SoundEffect;

    abstract protected void Effect(GameObject player);

    virtual public void Collected(GameObject player) {
        Effect(player);
        AudioSource.PlayClipAtPoint(m_SoundEffect, player.transform.position);
        gameObject.SetActive(false);
    }
}
