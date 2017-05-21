using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatUpdate : MonoBehaviour
{
    public Text dexterity;
    public Text strength;
    public Text intellect;

    private PlayerParty playerParty;

	void Start ()
    {
        playerParty = FindObjectOfType<PlayerParty>();
	}
	
	public void PlayerMember0()
    {
        dexterity.text = playerParty.characters[0].Dexterity.ToString();
        strength.text = playerParty.characters[0].Strength.ToString();
        intellect.text = playerParty.characters[0].Intelect.ToString();
    }

    public void PlayerMember1()
    {
        dexterity.text = playerParty.characters[1].Dexterity.ToString();
        strength.text = playerParty.characters[1].Strength.ToString();
        intellect.text = playerParty.characters[1].Intelect.ToString();
    }

    public void PlayerMember2()
    {
        dexterity.text = playerParty.characters[2].Dexterity.ToString();
        strength.text = playerParty.characters[2].Strength.ToString();
        intellect.text = playerParty.characters[2].Intelect.ToString();
    }
}
