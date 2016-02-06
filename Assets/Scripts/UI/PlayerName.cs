using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

    public Text enteredPlayerName;

	public void SetPlayerName()
    {
        GameInformation.PlayerName = enteredPlayerName.text;
        GameInformation.PlayerControllable = true;
    }
}
