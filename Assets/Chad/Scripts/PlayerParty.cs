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
        AddPartyMember(1, "Chad", characterType.Warrior, 5);
        AddPartyMember(2, "John", characterType.Warrior, 5);
        AddPartyMember(3, "Jake", characterType.Warrior, 5);
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

        //print(Input.inputString);
    }

    public void MovePlayer(Vector3 moveDestination)
    {
        Vector3 movePosition = Vector3.Lerp(transform.position, moveDestination, moveSpeed);

        transform.position = movePosition;
    }
    public void AddPartyMember(int partyPosition, string name, characterType charType, int level)
    {
        characters[partyPosition - 1] = new BaseCharacter(name, charType, level);
        print(characters[partyPosition - 1].GetName());
    }
}
