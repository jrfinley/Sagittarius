using UnityEngine;
using System.Collections;

public class MonsterParty : MonoBehaviour
{
    //Instantiate(monsterParty, transform.position, transform.rotation); //Spawning, throw this somewhere in WorldGen where monster rooms are selected

    public float moveXAmount,
                 moveZAmount;

    public int minPartySize = 1,
           maxPartySize = 6;

    public Rigidbody rb;

    public Transform playerParty;

    public Vector3 movePosition;

    private float rotationDamping = 10;

    public float moveSpeed;

    public float posSnapDistance;

    [SerializeField]
    private Sprite icon;

    private bool isMoving;

    private Room currentRoom;

    private PlayerEventManager eventManager;

    private MonsterManager monsterManager;

    public BaseMonster[] baseMonsters;

    void Start ()
    {
        InitializeParty();
    }

    void InitializeParty()
    {
        rb = GetComponent<Rigidbody>();
        baseMonsters = new BaseMonster[Random.Range(minPartySize, maxPartySize)];

        movePosition = transform.position;
        eventManager = FindObjectOfType<PlayerEventManager>();
        //eventManager.OnPlayerMove += RandomizeMoveInput;
    }

    private void OnDisable()
    {
        eventManager.OnPlayerMove -= RandomizeMoveInput;
    }
    private void OnDestroy()
    {
        eventManager.OnPlayerMove -= RandomizeMoveInput;
    }

    void RandomizeMoveInput()
    {
        Vector3 input = Vector3.zero;
        input.x = (int)Random.Range(-1f, 1f);

        if (input.x == 0)
        {
            float percentCheck = (int)Random.Range(0f, 1f);

            if (percentCheck < 0.5f)
                input.z = -1;
            else
                input.z = 1;
        }

        SetMoveDirection(input);
    }
    Room GetRoom(Vector3 checkPosition)
    {
        Room room = null;
        Collider[] moveSquares = Physics.OverlapSphere(checkPosition, transform.localScale.x);

        for (int i = 0; i < moveSquares.Length; i++)
            if (moveSquares[i].gameObject.GetComponent<Room>())
                room = moveSquares[i].gameObject.GetComponent<Room>();

        return room;
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        //uncomment connection stuff when dungeon connections are done

        if (isMoving == true)
            return;
        else
            isMoving = true;

        if (currentRoom == null)
            currentRoom = GetRoom(transform.position);

        Vector3 oldPosition = transform.position;
        //Transform connection = null;

        if (moveDirection.z > 0)
        {
            //connection = currentRoom.Connections.northConnections[0];
            movePosition.z += moveZAmount;
        }
        else if (moveDirection.z < 0)
        {
            //connection = currentRoom.Connections.southConnections[0];
            movePosition.z -= moveZAmount;
        }
        else if (moveDirection.x > 0)
        {
            //connection = currentRoom.Connections.eastConnections[0];
            movePosition.x += moveXAmount;
        }
        else if (moveDirection.x < 0)
        {
            //connection = currentRoom.Connections.westConnections[0];
            movePosition.x -= moveXAmount;
        }

        Room targetRoom = GetRoom(movePosition);

        //for (int i = 0; i < currentRoom.Connections.closedConnections.Count; i++)
        //    if (connection == currentRoom.Connections.closedConnections[i])
        //        targetRoom = null;

        if (targetRoom == null)
        {
            movePosition = oldPosition;
            isMoving = false;
            return;
        }

        StartCoroutine(MovePlayer(targetRoom.transform.position));
    }

    IEnumerator MovePlayer(Vector3 targetPosition)
    {
        float loopCutoff = 0;
        Vector3 oldPosition = transform.position;

        while (transform.position != targetPosition && loopCutoff < 5)
        {
            Vector3 moveDir = (targetPosition - transform.position);

            if (moveDir.magnitude > posSnapDistance)
            {
                moveDir = moveDir.normalized * moveSpeed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + moveDir);
            }
            else
            {
                transform.position = targetPosition;
            }

            loopCutoff += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        if (loopCutoff >= 5)
        {
            transform.position = oldPosition;
            movePosition = oldPosition;
            isMoving = false;
            Debug.LogError("Move player while loop reached cut off time");
            yield break;
        }

        isMoving = false;
        eventManager.FireOnPlayerMove();
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    //Testing
    /*public void Move ()
    {
        if (transform.position != movePosition)
            return;

        Vector3 oldPosition = transform.position;

        Collider[] moveSquares = Physics.OverlapSphere(movePosition, 1f);
        Debug.Log(moveSquares.Length);

        if (moveSquares.Length == 0)
        {
            movePosition = oldPosition;
            return;
        }

    }

    void FindPlayerParty()
    {
        Quaternion rotation = Quaternion.LookRotation(playerParty.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    void Update()
    {
        FindPlayerParty();

        if (Input.GetKeyDown("m"))  //Switch out with overt action
        {
            Move();
        }

    }
        

    */


}
