using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public string dialogID;

	private bool interactable;
	private ModalPanel modalPanel;
	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		modalPanel = ModalPanel.Instance ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		if (interactable) 
		{
			if(Input.GetKeyUp("e"))
			{
				if (modalPanel.modalPanelObject.activeInHierarchy)
                {
					modalPanel.ClosePanel ();
                    GameInformation.PlayerControllable = true;
				} else 
				{
                    GameInformation.PlayerControllable = false;

					ModalPanelDetails modalPanelDetails = new ModalPanelDetails ();

					string temp = DialogueData.LoadFromXML (dialogID);
					modalPanelDetails.text = temp.Replace ("PlayerName", GameInformation.PlayerName);

					modalPanelDetails.title = this.gameObject.name;
					modalPanelDetails.iconImage = spriteRenderer.sprite;
                    modalPanel.NewChoice (modalPanelDetails);
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			interactable = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			interactable = false;
			modalPanel.ClosePanel ();
		}
	}
		
}
