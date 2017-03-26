using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    public PlayerParty[] playerParty;

    private float tempHealth;
    private float tempLevel;
    private string tempName;

    void Start()
    {
        playerParty = GetComponents<PlayerParty>();
    }

    public void StoreData()
    {
        Vector3 pos = transform.position;
        data.posX = pos.x;
        data.posY = pos.y;
        data.posZ = pos.z;
        foreach (PlayerParty player in playerParty)
        {
            data.playerParty = player.characters;
            data.name = tempName;
            data.level = tempLevel;
            data.health = tempHealth;
            //data.name = player.GetComponent<BaseCharacter>().Name;
            //data.level = player.GetComponent<BaseCharacter>().Level;
            //data.health = player.GetComponent<BaseCharacter>().Health;
        }       
    }

    public void LoadData()
    {
        transform.position = new Vector3(data.posX, data.posY, data.posZ);
        foreach(PlayerParty player in playerParty)
        {
            player.characters = data.playerParty;
            tempName = data.name;
            tempLevel = data.level;
            tempHealth = data.health;
            //player.GetComponent<BaseCharacter>().Name = data.name;
            //player.GetComponent<BaseCharacter>().Level = (int)data.level;
            //player.GetComponent<BaseCharacter>().Health = (int)data.health;
        }
    }

    void OnEnable()
    {
        SaveData.OnLoaded += delegate { LoadData(); };
        SaveData.OnBeforeSave += delegate { StoreData(); };
        SaveData.OnBeforeSave += delegate { SaveData.AddActorData(data); };

    }

    void OnDisable()
    {
        SaveData.OnLoaded -= delegate { LoadData(); };
        SaveData.OnBeforeSave -= delegate { StoreData(); };
        SaveData.OnBeforeSave -= delegate { SaveData.AddActorData(data); };
    }
}

public class ActorData
{
    [XmlAttribute("Name")]
    public string name;

    [XmlElement("PosX")]
    public float posX;

    [XmlElement("PosY")]
    public float posY;

    [XmlElement("PosZ")]
    public float posZ;

    [XmlElement("Health")]
    public float health;

    [XmlElement("Level")]
    public float level;

    [XmlArray("PlayerParty")]
    public BaseCharacter[] playerParty;
}
