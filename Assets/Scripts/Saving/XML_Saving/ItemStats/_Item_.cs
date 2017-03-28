using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class _Item_
{
    [XmlAttribute("Name")]
    public string _name;

    [XmlAttribute("Description")]
    [Multiline]
    public string _desc;

    [XmlElement("ID")]
    public float _id;

    [XmlElement("Health")]
    public float _health;

    [XmlElement("Damage")]
    public float _damage;

    [XmlElement("Strength")]
    public float _strength;

    [XmlElement("Dexterity")]
    public float _dexterity;

    [XmlElement("Intellect")]
    public float _intellect;

    [XmlElement("GoldValue")]
    public float _goldValue;

    [XmlElement("ScrapValue")]
    public float _scrapValue;

    [XmlElement("ItemCount")]
    public float _currentItemCount;
}