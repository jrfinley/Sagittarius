using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    public float moveSpeed;

    public Vector3 movePosition;

    public BaseCharacter[] characters;

    void Start()
    {
        movePosition = transform.position;

        //AddPartyMember example
        AddPartyMember(1, "Chad", ECharacterType.WARRIOR, 5);
    }
    void Update()
    {
        DetectInput();
    }
    void FixedUpdate()
    {
        MovePlayer(movePosition);
    }

    void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movePosition += new Vector3(0, 0, 15);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movePosition += new Vector3(-15, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movePosition += new Vector3(0, 0, -15);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movePosition += new Vector3(15, 0, 0);
        }
    }

    public void MovePlayer(Vector3 moveDestination)
    {
        Vector3 movePosition = Vector3.Lerp(transform.position, moveDestination, moveSpeed);

        transform.position = movePosition;
    }
    public void AddPartyMember(int partyPosition, string name, ECharacterType charType, int level)
    {
        characters[partyPosition - 1] = new BaseCharacter(name, charType, level);
        print(characters[partyPosition - 1].GetName());
    }
}
