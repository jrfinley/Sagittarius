using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
public class ActorController_xml : MonoBehaviour
{
    public Button saveButton;
    public Button loadButton;
    public const string playerPath = "Prefabs/Player";

    private static string dataPath = string.Empty;

    private GameObject preventDuplicates;
    private bool hasSpawned;

    private GameObject actorObj;
    
    void Awake()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            dataPath = System.IO.Path.Combine(Application.persistentDataPath, "Resources/actors.xml");
        else
            dataPath = System.IO.Path.Combine(Application.dataPath, "Resources/actors.xml");

        
    }

    void Start()
    {
        actorObj = GameObject.FindGameObjectWithTag("Player");
        Destroy(actorObj);
        CreateActor(playerPath, new Vector3(0, 1, 0), Quaternion.identity);



    }

    public static Actor_xml CreateActor(string path, Vector3 pos, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject go = GameObject.Instantiate(prefab, pos, rotation) as GameObject;

        Actor_xml actor = go.GetComponent<Actor_xml>() ?? go.AddComponent<Actor_xml>();

        return actor;
    }

    public static Actor_xml CreateActor(ActorData_xml data, string path, Vector3 pos, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject go = GameObject.Instantiate(prefab, pos, rotation) as GameObject;

        Actor_xml actor = go.GetComponent<Actor_xml>() ?? go.AddComponent<Actor_xml>();

        actor.data = data;

        return actor;
    }

    void OnEnable()
    {
        saveButton.onClick.AddListener(delegate { SaveData.Save(dataPath, SaveData.actorContainer); });
        loadButton.onClick.AddListener(delegate { SaveData.Load(dataPath); });

    }

    void OnDisable()
    {
        saveButton.onClick.RemoveListener(delegate { SaveData.Save(dataPath, SaveData.actorContainer); });
        loadButton.onClick.RemoveListener(delegate { SaveData.Load(dataPath); });
    }
}
*/