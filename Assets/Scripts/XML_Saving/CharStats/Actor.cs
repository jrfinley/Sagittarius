using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    public BaseCharacter baseCharacter;

    private int _level;
    private int _health;
    private string _name;

    void Start()
    {
        baseCharacter = FindObjectOfType<BaseCharacter>();
    }

    public void StoreData()
    {
        Vector3 pos = transform.position;
        data.posX = pos.x;
        data.posY = pos.y;
        data.posZ = pos.z;
        data.name = baseCharacter.GetName();
        data.health = baseCharacter.GetHealth();
        data.level = baseCharacter.GetLevel();   
    }

    public void LoadData()
    {
        transform.position = new Vector3(data.posX, data.posY, data.posZ);
        _name = data.name;
        _level = (int)data.level;
        _health = (int)data.health;
        //SetAfterLoad();
    }

    /*void SetAfterLoad()
    {
        baseCharacter.SetName(_name);
        baseCharacter.AlterHealth(_health);
        baseCharacter.AlterExperience(_level);
    }*/

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
}
