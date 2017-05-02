using UnityEngine;
using System.Collections;

public class MonsterParty : MonoBehaviour
{
    public BaseMonster[] monsters;

    public Rigidbody rb;

    public Vector3 movePosition;

    public int minPartySize = 1,
               maxPartySize = 6;

    [SerializeField]
    private Sprite icon;

    void Start ()
    {        
        rb = GetComponent<Rigidbody>();
        monsters = new BaseMonster[Random.Range(minPartySize, maxPartySize)];   
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    //Monsters spawn via Dungeon Gen
    //Monsters move toward player after fail in barrier checks, movement possible the same as player party or use room passing

}
