using UnityEngine;
using System.Collections;

public class PrologueManager : MonoBehaviour {

	//SCRIPT CURRENTLY FOR TESTING PURPOSES

	void Update()
	{
		CheckPrologueEndConditions ();
	}

	public static void CheckPrologueEndConditions()
	{
		if (GameInformation.interactions.ContainsKey ("Crew Member 1") &&
			GameInformation.interactions.ContainsKey ("Crew Member 2") &&
			GameInformation.interactions.ContainsKey ("Crew Member 3")) 
		{
			Debug.Log ("end!");
		}

	}
}
