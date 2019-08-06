
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class loader : MonoBehaviour
{

    void Start()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("Assets/label.xml");

        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
        {
            Debug.Log(node.Name);
            Debug.Log(node.InnerText);
        }

    }

}