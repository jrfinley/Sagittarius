using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    public int maxEquipmentLoad,
               equipmentLoad;

    public float moveSpeed;

    public Vector3 movePosition;

    public BaseCharacter[] characters;

    public Rigidbody rb;

    void Start()
    {
		rb = GetComponent<Rigidbody> ();
        movePosition = transform.position;

        //AddPartyMember example
        AddPartyMember(1, "Chad", ECharacterType.ROGUE, 5);
        AddPartyMember(2, "John", ECharacterType.WARRIOR, 7);
    }
    void FixedUpdate()
    {
        MovePlayer(movePosition);
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        //Add something to check for open square here and if there is one, set moveDirection to zero

        if (moveDirection.z > 0)
        {
            movePosition.z += 15;
        }
        else if (moveDirection.z < 0)
        {
            movePosition.z -= 15;
        }
        else if (moveDirection.x > 0)
        {
            movePosition.x += 15;
        }
        else if (moveDirection.x < 0)
        {
            movePosition.x -= 15;
        }
    }
    public void MovePlayer(Vector3 moveDestination)
    {
        Vector3 movePosition = Vector3.Lerp(transform.position, moveDestination, moveSpeed);

        transform.position = movePosition;
    }
    public void AddPartyMember(int partyPosition, string name, ECharacterType charType, int level)
    {
        if (characters[partyPosition - 1] != null)
        {
            RemovePartyMember(partyPosition);
        }

        characters[partyPosition - 1] = gameObject.AddComponent<BaseCharacter>();
        characters[partyPosition - 1].InitializeCharacter(name, charType, level);

        maxEquipmentLoad += characters[partyPosition - 1].GetEquipmentCapacity();

        print("Added " + characters[partyPosition - 1].GetName() + " to the party");
    }
    public void RemovePartyMember(int partyPosition)
    {
        maxEquipmentLoad -= characters[partyPosition - 1].GetEquipmentCapacity();
        characters[partyPosition - 1] = null;
    }
}
