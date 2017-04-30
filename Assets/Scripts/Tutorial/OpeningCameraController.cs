using UnityEngine;
using System.Collections;

public class OpeningCameraController : MonoBehaviour
{
    Transition transition;
    public Animator oracleAnimator;
    public UIManager ui;
    public string[] oracleDialogueSetIntro01;

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

    public void TriggleOracleShardIntroAnimation()
    {
        oracleAnimator.SetTrigger("oracle_intro_1");
    }

    public void OracleSpeakIntro_01()
    {
        ui.CreateNewDialogueBox(oracleDialogueSetIntro01[0]);
        ui.CreateNewDialogueBox(oracleDialogueSetIntro01[1]);
        ui.CreateNewDialogueBox(oracleDialogueSetIntro01[2]);
        ui.CreateNewDialogueBox(oracleDialogueSetIntro01[3]);
    }


}
