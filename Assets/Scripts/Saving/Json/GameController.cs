using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button saveButton;
    public Button loadButton;

    public GameObject playerPrefab;
    public const string playerPath = "Prefabs/Player";

    private static string dataPath = string.Empty;

    void Awake()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");//path combiner combines strings we put in with backslash, last bit is file name
    }

    public static Actor CreateActor(string path, Vector3 pos, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject go = Instantiate(prefab, pos, rotation) as GameObject;

        Actor actor = go.GetComponent<Actor>() ?? go.AddComponent<Actor>();//if no actor componetn create and return it

        return actor;
    }

    public static Actor CreateActor(ActorData data, string path, Vector3 pos, Quaternion rotation)
    {
        Actor actor = CreateActor(path, pos, rotation);

        actor.data = data;

        return actor;
    }

    public void Save()
    {
        SaveData.Save(dataPath, SaveData.actorContainer);
    }

    public void Load()
    {
        SaveData.Load(dataPath);
    }
}
