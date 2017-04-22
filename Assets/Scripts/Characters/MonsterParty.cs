using UnityEngine;
using System.Collections;

public class MonsterParty : MonoBehaviour
{
    public BaseMonster[] monsters;

    public Rigidbody rb;

    public Vector3 movePosition;

    private int minPartySize,
                maxPartySize;

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

    public void AddStatusEffect<T>(T statusEffect) where T : BaseStatusEffect
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i] != null)
                monsters[i].AddStatusEffect(statusEffect);
        }
    }
    public void AddStatusEffect<T>(T statusEffect, int partySlot) where T : BaseStatusEffect
    {
        partySlot = Mathf.Clamp(partySlot, 1, maxPartySize);
        partySlot -= 1;

        monsters[partySlot].AddStatusEffect(statusEffect);
    }

    //Change buff stuff to poison
    public void RemoveStatusEffect(EBuffType typeToRemove)
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i] != null)
                monsters[i].RemoveStatusEffect(typeToRemove);
        }
    }
    public void RemoveStatusEffect(EBuffType typeToRemove, int partySlot)
    {
        partySlot = Mathf.Clamp(partySlot, 1, maxPartySize);
        partySlot -= 1;

        monsters[partySlot].RemoveStatusEffect(typeToRemove);
    }
}
