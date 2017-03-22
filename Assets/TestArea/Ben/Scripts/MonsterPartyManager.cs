using UnityEngine;
using System.Collections;

public class MonsterPartyManager : MonoBehaviour
{
    public Vector3 position;

    private Rigidbody rigidBody = null;

    [SerializeField] private int partyNum = 0;
    [SerializeField] private int monsterLevel = 0;

    private int minMonsters = 0;
    private int maxMonsters = 5;
    private int characterLevel = 0;

    private float speed;

    [SerializeField] private BaseMonster[] monsterParty;
    private PlayerParty playerParty = null;
    private BaseCharacter player = null;

    public GameObject playerObject;

	void Start ()
    {
        position = transform.position;
        rigidBody = transform.GetComponent<Rigidbody>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerParty = playerObject.GetComponent<PlayerParty>();
        player = playerObject.GetComponent<BaseCharacter>();
        characterLevel = player.GetLevel();

        InitializeParty();
    }
	
	void Update ()
    {
	
	}

    //to be changed
    IEnumerator Move(Vector3 Destination)
    {
        float loopCutoff = 0;
        Vector3 oldposition = transform.position;

        while (transform.position != position && loopCutoff < 5)
        {
            Vector3 moveDir = (position - transform.position);

            if (moveDir.magnitude > 0.2f)
            {
                moveDir = moveDir.normalized * speed * Time.fixedDeltaTime;
                rigidBody.MovePosition(rigidBody.position + moveDir);
            }
            else
            {
                transform.position = position;
            }

            loopCutoff += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        if (loopCutoff >= 5)
        {
            transform.position = oldposition;
            Debug.LogError("Move player while loop reached cut off time");
        }
    }

    private void InitializeParty()
    {
        partyNum = Random.Range(2, maxMonsters);

        int minLevel;
        minLevel = characterLevel - 2;
        if (minLevel <= 0)
        {
            minLevel = 1;
        }
        monsterLevel = Random.Range(minLevel, characterLevel + 2);

        monsterParty = new BaseMonster[partyNum]; 
        for (int i = 0; i < partyNum; i++)
        {
            monsterParty[i] = gameObject.AddComponent<BaseMonster>();
            monsterParty[i].SetLevel(monsterLevel);
        }
    }
}

//Create an enemy-party system that the world generator can apply to specific rooms.Should a player encounter a room with an enemy party inside, a combat sequence will be initiated.
//Allow the enemy parties to move around the dungeon. This enemy movement should not happen automatically, only when prompted by specific player actions (such overt actions).