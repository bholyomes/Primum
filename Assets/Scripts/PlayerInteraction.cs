using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public string text;

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
				if (modalPanel.modalPanelObject.activeInHierarchy) {
					modalPanel.ClosePanel ();
				} else 
				{
					ModalPanelDetails modalPanelDetails = new ModalPanelDetails ();
					modalPanelDetails.question = text;
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
