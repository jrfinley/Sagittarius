using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneCamera : MonoBehaviour
{
    Transition transition;
    public Animator oracleAnimator;
    public TutorialController tutorialController;
    public GameObject deathBoulders;
    void Awake()
    {
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
    }
    public void FadeInTransition() //CALLED BY CAMERA ANIMATION
    {
        transition.StartFade(Color.clear, 2f);
    }
    public void FadeOutTransition() //CALLED BY CAMERA ANIMATION
    {
        transition.StartFade(new Color(0.05882f, 0f, 0.04314f, 1f), 1f);
    }

    public void SlowFadeOutTransition() //CALLED BY CAMERA ANIMATION
    {
        transition.StartFade(new Color(0.05882f, 0f, 0.04314f, 1f), 2f);
    }

    public void TriggleOracleShardIntroAnimation()
    {
        oracleAnimator.SetTrigger("oracle_intro_1");
    }
    public void OracleSpeakIntro_01()
    {
        tutorialController.OracleSpeakIntro_01();
    }

    public void TriggerOracleDeathAnimation()
    {
        oracleAnimator.SetTrigger("oracle_die");
    }

    public void TriggerEndCutScene()
    {
        this.GetComponent<Animator>().SetTrigger("ending_cutscene");
    }

    public void ActivateBoulders()
    {
        deathBoulders.SetActive(true);
    }

    public void LoadTownScene()
    {
        SceneManager.LoadScene("Town");
    }
}
