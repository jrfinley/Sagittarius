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
		rb = GetComponent<Rigidbody>();
        movePosition = transform.position;

        //AddPartyMember example
        AddPartyMember(1, "Chad", ECharacterType.ROGUE, 5);
        AddPartyMember(2, "John", ECharacterType.WARRIOR, 7);
        //AddPartyMember example
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        if (transform.position != movePosition)
            return;

        Vector3 oldPosition = transform.position;

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

        Collider[] moveSquares = Physics.OverlapSphere(movePosition, 0.1f);

        if (moveSquares.Length == 0)
        {
            movePosition = oldPosition;
            return;
        }

        StartCoroutine(MovePlayer(moveDirection));
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

    IEnumerator MovePlayer(Vector3 moveDestination)
    {
		float loopCutoff = 0;
		Vector3 oldPosition = transform.position;
		
        while (transform.position != movePosition && loopCutoff < 5)
        {
            Vector3 moveDir = (movePosition - transform.position);

            if (moveDir.magnitude > 0.2f)
            {
                moveDir = moveDir.normalized * moveSpeed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + moveDir);
            }
            else
            {
                transform.position = movePosition;
            }
			
			i += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
		
		if (loopCutoff >= 5)
		{
			transform.position = oldPosition;
			print("Reached loop cut off time");
		}
    }
}
