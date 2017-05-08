using UnityEngine;
using System.Collections;

public class MonsterParty : MonoBehaviour
{
    public BaseMonster[] monsters;

    public Rigidbody rb;

    public Transform playerParty;

    public Vector3 movePosition;

    private float rotationDamping = 10;

    public int minPartySize = 1,
               maxPartySize = 6;

    [SerializeField]
    private Sprite icon;

    void Start ()
    {        
        rb = GetComponent<Rigidbody>();
        monsters = new BaseMonster[Random.Range(minPartySize, maxPartySize)];
        movePosition = transform.position;
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

    }*/

     //Instantiate(monsterParty, transform.position, transform.rotation); //By Steven for testing

}
