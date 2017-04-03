using UnityEngine;
using System.Collections;
using System.IO;

public class SaveData
{
    public static ActorContainer actorContainer = new ActorContainer();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;

    public static void Load(string path)
    {
        //actorContainer = LoadActors(path);

        foreach (ActorData data in actorContainer.actors)
        {
            GameController.CreateActor(data, GameController.playerPath, data.pos, Quaternion.identity);
        }
        OnLoaded();

        ClearActorList();
    }

    public static void Save(string path, ActorContainer actors)
    {
        OnBeforeSave();

        //SaveActors(path, actors);

        ClearActorList();
    }

    public static void AddActorData(ActorData data)
    {
        actorContainer.actors.Add(data);
    }

    //avoid duplicate data, after save after we load clear
    public static void ClearActorList()
    {
        actorContainer.actors.Clear();
    }

    /*private static ActorContainer LoadActors(string path)
    {
        string json = File.ReadAllText(path);//loading all text in the file into a string

        return JsonUtility.FromJson<ActorContainer>(json);//parse the json into actor container type
    }

    //if file doesn't exist it will create it
    private static void SaveActors(string path, ActorContainer actors)
    {
        string json = JsonUtility.ToJson(actors);

        StreamWriter sw = File.CreateText(path);
        sw.Close();

        File.WriteAllText(path, json);
    }*/
}
