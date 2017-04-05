using UnityEngine;
using System.Collections;

public class MonsterPartyManager : MonoBehaviour
{
    public Vector3 position;

    [SerializeField] private int _partyNum = 0;
    [SerializeField] private int _itemLevel = 0;

    private int _minMonsters = 2;
    private int _maxMonsters = 6;

    private int _levelModifier = 2;

    private int _size = 0;
    private int _maxSize = 0;

    [SerializeField] private BaseMonster[] _monsterParty;
    [SerializeField] private int[] _levelArray;
    [SerializeField] private EMonsterType[] _typeArray;
    [SerializeField] private int[] _lootValueArray;

    private GameObject _playerObject;
    private GameObject _room;

	void Start ()
    {
        position = transform.position;
        _playerObject = GameObject.FindGameObjectWithTag("Player");

        InitializeParty();
    }
	
	void Update ()
    {
        //if (_room == _player._currentRoom)
        //{
        //    Encounter();
        //}
    }

    private void InitializeParty()
    {
        _partyNum = Random.Range(_minMonsters, _maxMonsters+1);

        _monsterParty = new BaseMonster[_partyNum];
        _levelArray = new int[_partyNum];
        _typeArray = new EMonsterType[_partyNum];
        _lootValueArray = new int[_partyNum];

        _maxSize = _maxMonsters;

        for (int i = 0; i < _partyNum; i++)
        {
            _levelArray[i] = LevelCalc();
            _typeArray[i] = TypeCalc(i);
            _lootValueArray[i] = LootCalc(i);
            
            _monsterParty[i] = gameObject.AddComponent<BaseMonster>();
            _monsterParty[i].SetLevel(_levelArray[i]);
            _monsterParty[i].SetType(_typeArray[i]);
        }
        //_room = currentroom;
    }

    private void CurrentRoom()
    {
        /*
            
        */
    }

    private void Encounter()
    {
        /*
            pass payload
            load battle scene
        */
    }
    private int LevelCalc()
    {
        int level;
        level = Random.Range(_itemLevel - _levelModifier, _itemLevel + _levelModifier + 1);

        if (level <= 0)
        {
            level = 1;
        }

        return level; 
    }
    private EMonsterType TypeCalc(int i)
    {
        EMonsterType monsterType;
        _size = _maxMonsters / _partyNum;

        if (_size == 3)
        {
            _size = 4;
        }

        if (_maxSize <= _size)
        {
            _size = _maxSize;
        }
        else if (_maxSize == 2 && i == _partyNum - 1)
        {
            _size++;

        }
        else if (_maxSize > 2 && i == _partyNum - 1)
        {
            _size++;
            _typeArray[i - 1]++;
            _monsterParty[i - 1].SetType(_typeArray[i-1]);
            _lootValueArray[i - 1] = LootCalc(i - 1);
        }

        _maxSize -= _size;

        switch (_size)
        {
            case 1:
                monsterType = EMonsterType.E_TEMP_ONE;
                break;

            case 2:
                monsterType = EMonsterType.E_TEMP_TWO;
                break;

            case 4:
                monsterType = EMonsterType.E_TEMP_THREE;
                break;

            default:
                monsterType = EMonsterType.E_TEMP_ONE;
                break;
        }

        return monsterType;
    }

    private int LootCalc(int i)
    {
        int lootValue;

        lootValue = (_itemLevel + (_levelArray[i] * ((int)_typeArray[i]+1)));

        if (lootValue <= 0)
        {
            lootValue = 1;
        }

        return lootValue;
    }

    public void MoveTowardsPlayer()
    {

    }

    public void SetItemLevel(int level)
    {
        _itemLevel = level;
    }
    public void SetLevelModifier(int mod)
    {
        _levelModifier = mod;
    }
}

//Should a player encounter a room with an enemy party inside, a combat sequence will be initiated.
//Allow the enemy parties to move around the dungeon. This enemy movement should not happen automatically, only when prompted by specific player actions (such overt actions).
//Monsters will have item drop tables that will have the chance randomly drop loot on death based on the type of monster and its level.