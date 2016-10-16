using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsController : MonoBehaviour {

    [SerializeField]
    private GameObject m_EasySign, m_MediumSign, m_HardSign;

    private Animator animator;
    private GameObject m_LastActived = null;


	// Use this for initialization
	void Start () {
        animator = GameObject.Find("Canvas").GetComponent<Animator>();
        m_LastActived = SetDifficulty(GamePreferencesManager.m_Instance.m_LevelDifficulty);
	}

    public void ChooseEasyDifficulty() {
        m_LastActived = SetDifficulty(LevelDifficulty.EASY);
    }

    public void ChooseMediumDifficulty() {
        m_LastActived = SetDifficulty(LevelDifficulty.MEDIUM);
    }

    public void ChooseHardDifficulty() {
        m_LastActived = SetDifficulty(LevelDifficulty.HARD);
    }


    private GameObject SetDifficulty(LevelDifficulty levelDifficulty) {
        if(m_LastActived != null)
            m_LastActived.SetActive(false);
        GamePreferencesManager.m_Instance.ConfigDifficulty(levelDifficulty);
        switch (levelDifficulty) {
            case LevelDifficulty.EASY:
                m_EasySign.SetActive(true);
                return m_EasySign;
            case LevelDifficulty.MEDIUM:
                m_MediumSign.SetActive(true);
                return m_MediumSign;
            case LevelDifficulty.HARD:
                m_HardSign.SetActive(true);
                return m_HardSign;
            default:
                return null;
        }
    }

    public void BackToMainMenu() {
        animator.SetBool("IsCallOptions", false);
        animator.SetTrigger("ExitOptions");
    }
}
