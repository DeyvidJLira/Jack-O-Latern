using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFaderController : MonoBehaviour {

    public static SceneFaderController m_Instance;

    [SerializeField]
    private GameObject m_FadePanel;

    [SerializeField]
    private Animator m_FadeAnimator;

    void Awake() {
        if(m_Instance == null) {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(this);
        }
    }

    public void LoadScene(string nameScene) {
        StartCoroutine(FadeInOut(nameScene));
    }

	IEnumerator FadeInOut(string nameScene) {
        m_FadePanel.SetActive(true);
        m_FadeAnimator.Play("FadeIn");

        yield return StartCoroutine(MyCoroutines.WaitForRealSeconds(1f));

        SceneManager.LoadScene(nameScene);
        m_FadeAnimator.Play("FadeOut");

        yield return StartCoroutine(MyCoroutines.WaitForRealSeconds(1f));

        m_FadePanel.SetActive(false); 
    }
}
