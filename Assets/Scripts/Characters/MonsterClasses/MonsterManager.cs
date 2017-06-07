using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> monsters;

    private MonsterParty monsterParty;

    void Start()
    {
        InitializeMonsterParty();
    }

    void InitializeMonsterParty()
    {
        monsterParty = FindObjectOfType<MonsterParty>();
        FindAllMonsters();
    }

    public void FindAllMonsters()
    {
        monsters.AddRange(GameObject.FindGameObjectsWithTag("MonsterParty"));
        //SortMonsters();
    }

    public void CreateMonster(EMonsterType monsterType, string name, int level)
    {
        BaseMonster newMonster = new BaseMonster();


        switch (monsterType)
        {
            case EMonsterType.E_TEMP_ONE:
                //newMonster.InitializeMonster(name, level);
                //AddMonster(newMonster);
                break;

            case EMonsterType.E_TEMP_TWO:
                //newMonster.InitializeMonster(name, level);
                //AddMonster(newMonster);
                break;

            case EMonsterType.E_TEMP_THREE:
                //newMonster.InitializeMonster(name, level);
                //AddMonster(newMonster);
                break;

            case EMonsterType.E_TEMP_BOSS:
                //newMonster.InitializeMonster(name, level);
                //AddMonster(newMonster);
                break;
        }
    }
    void SortMonsters()
    {
        monsters.Clear();
    }
    void AddMonster(BaseMonster newMonster)
    {
        //monsters.Add(newMonster);
    }
}
