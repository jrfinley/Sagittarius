using UnityEngine;
using System.Collections;

public class MonsterPartyManager : MonoBehaviour
{
    public Vector3 position;

    private Rigidbody _rigidBody = null;

    [SerializeField] private int _partyNum = 0;
    [SerializeField] private int _itemLevel = 0;

    private int _minMonsters = 2;
    private int _maxMonsters = 6;
    private int _characterLevel = 0;
    private int _levelModifier = 0;

    private float _speed;

    [SerializeField] private BaseMonster[] _monsterParty;
    [SerializeField]private int[] _levelArray;
    [SerializeField]private EMonsterType[] _typeArray;
    private PlayerParty _playerParty = null;
    private BaseCharacter _player = null;

    private GameObject _playerObject;
    private GameObject _room;

	void Start ()
    {
        position = transform.position;
        _rigidBody = transform.GetComponent<Rigidbody>();
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerParty = _playerObject.GetComponent<PlayerParty>();
        _player = _playerObject.GetComponent<BaseCharacter>();
        _characterLevel = _player.GetLevel();

        InitializeParty();
    }
	
	void Update ()
    {
        //if (_room == _player._currentRoom)
        //{
        //    Encounter();
        //}
    }

    //to be changed
    //IEnumerator Move(Vector3 Destination)
    //{
        
    //}

    private void InitializeParty()
    {
        _partyNum = Random.Range(_minMonsters, _maxMonsters);

        _monsterParty = new BaseMonster[_partyNum];
        _levelArray = new int[_partyNum];
        _typeArray = new EMonsterType[_partyNum];

        for (int i = 0; i < _partyNum; i++)
        {
            _levelArray[i] = LevelCalc();
            _typeArray[i] = TypeCalc(_partyNum);
            
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
        level = Random.Range(_itemLevel - _levelModifier, _itemLevel + _levelModifier);

        if (level <= 0)
        {
            level = 1;
        }

        return level; 
    }
    private EMonsterType TypeCalc(int partyNum)
    {
        EMonsterType type = EMonsterType.E_TEMP_ONE;
        int size = _maxMonsters/ partyNum;
        int totalSize = _maxMonsters;

        if (size == 3)
        {
            size = 4;
        }
        

        if (size > totalSize)
        {
            size = totalSize;
        }
        totalSize -= size;
        
        Debug.Log(totalSize);


        switch (size)
        {
            case 1:
                type = EMonsterType.E_TEMP_ONE; // type/size one
                break;

            case 2:
                type = EMonsterType.E_TEMP_TWO; // type/size two
                break;

            case 4:
                type = EMonsterType.E_TEMP_THREE; // type/size three (size four)
                break;
        }

        return type;

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