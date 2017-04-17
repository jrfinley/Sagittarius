using UnityEngine;
using System.Collections;

public class EndSequence : MonoBehaviour
{
    private CombatPanel cP;

    private BaseMonster monster;

    void Start()
    {
        monster.GetHealth();

        monster.SetHealth(100);
    }

    void OnCollisionEnter(Collision monster)
    {
        if(monster.gameObject.tag == "Acitvate")
        {

        }
    }
}