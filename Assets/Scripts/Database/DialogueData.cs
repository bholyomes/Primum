using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

[System.Serializable]
[XmlRoot("Dialogue")]
public class DialogueData {

	[XmlAttribute("id")]
	public string text;

	public static string LoadFromXML(string id)
	{
		string filepath = Application.dataPath + "/Scripts/Database/Dialogue.xml";

		XmlDocument xmlDoc = new XmlDocument ();

		if (File.Exists (filepath)) 
		{
			xmlDoc.Load (filepath);

			XmlNodeList nodeList = xmlDoc.GetElementsByTagName ("text");

			foreach (XmlNode node in nodeList) {
				if (node.Attributes ["id"].Value == id) {
					return node.InnerText;
				}
			}
		}
		return "error";
	}
}
	
