using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
/*
public class SaveData_xml
{
    public static ActorContainer_xml actorContainer = new ActorContainer_xml();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;

    public static void Load(string path)
    {
        actorContainer = LoadActors(path);

        foreach(ActorData data in actorContainer.actors)
        {
            ActorController_xml.CreateActor(data, ActorController_xml.playerPath, 
                new Vector3(data.posX, data.posY, data.posZ), Quaternion.identity);

        }

        OnLoaded();
    }

    public static void Save(string path, ActorContainer_xml actors)
    {
        OnBeforeSave();

        SaveActors(path, actors);

        ClearActors();
    }

    public static void AddActorData(ActorData data)
    {
        actorContainer.actors.Add(data);

    }

    public static void ClearActors()
    {
        actorContainer.actors.Clear();
    }

    private static ActorContainer_xml LoadActors(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ActorContainer_xml));

        FileStream stream = new FileStream(path, FileMode.Open);

        ActorContainer_xml actors = serializer.Deserialize(stream) as ActorContainer_xml; 

        stream.Close();

        return actors;
    }

    private static void SaveActors(string path, ActorContainer_xml actors)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ActorContainer_xml));

        FileStream stream = new FileStream(path, FileMode.Truncate);

        serializer.Serialize(stream, actors);

        stream.Close();
    }
}
*/