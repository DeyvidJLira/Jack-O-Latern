using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

    public static MusicController m_Instance { get; private set; }

    private AudioSource m_AudioSource;

    void Awake() {
        if(m_Instance == null) {
            m_Instance = this;
            m_AudioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(this);
        }
    }

    public void PlayMusic(bool play) {
        if(play) {
            if(!m_AudioSource.isPlaying) {
                m_AudioSource.Play();
            }
        } else {
            if(m_AudioSource.isPlaying) {
                m_AudioSource.Stop();
            }
        }
    }
}
