//Aidan Lawrence
//Controls the combat panel & entity information found inside it.
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CombatPanel : MonoBehaviour
{
    public GameObject combatCardObj;
    public List<CombatCard> debug_testCombatCards = new List<CombatCard>(); //Just here to test the UI

    /*
    public void CreateNewCombatMatch(Enemy[] enemies) //I plan to have this function read in an array of enemy classes and fill-in the enemy combat cards automatically.
    {

    }
    */

    public void Run()
    {
        EndCombat();
    }	

    public void Attack()
    {
        Debug_TestCombatRound();
    }

    public void Heal()
    {
        Debug_TestHealAllRound();
    }

    public void EndCombat()
    {
        //gameObject.SetActive(false);
        SceneManager.UnloadScene("Combat");
    }

    public void Debug_TestCombatRound()
    {
        foreach(CombatCard cc in debug_testCombatCards)
        {
            int hit = Random.Range(-25, 0);
            cc.AlterHealth(hit);
        }
    }

    public void Debug_TestHealAllRound()
    {
        foreach (CombatCard cc in debug_testCombatCards)
        {
            int hit = Random.Range(0, 25);
            cc.AlterHealth(hit);
        }
    }
}
