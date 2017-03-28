using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ItemCollection")]
public class ItemContainer
{
    [XmlArray("Items")]
    [XmlArrayItem("Item")]
    public List<_Item_> items = new List<_Item_>();


    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(ItemContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static ItemContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ItemContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ItemContainer;
        }
    }

    

    
}
