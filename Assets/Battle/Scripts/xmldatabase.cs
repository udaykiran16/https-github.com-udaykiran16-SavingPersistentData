/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class xmldatabase : MonoBehaviour
{
    public static xmldatabase ins;
    public void Awake()
    {
        ins = this;
    }

    public itemDatabase itemDB;

    void Start()
    {
        var serializer = new XmlSerializer(typeof(itemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/Assets/streamingfiles/xml/limb.xml", FileMode.Create);
        serializer.Serialize(stream, this);
        stream.Close(); 
    }
}

[System.Serializable]
public class Dataentry
{
 
} 

[System.Serializable]
public class itemDatabase
{
    public List<Dataentry> list = new List<Dataentry>();
}*/