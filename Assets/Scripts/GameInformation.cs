using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameInformation {

	public static string PlayerName { get; set; }
    public static bool PlayerControllable { get; set; }

	public static Dictionary<string, int> interactions = new Dictionary<string, int> ();

	public static void AddInteraction(string key, int value)
	{
		if (!interactions.ContainsKey (key)) {
			interactions.Add (key, value);
		} else if (interactions.ContainsKey (key)) {
			interactions [key] = value;
		}
	}


}
