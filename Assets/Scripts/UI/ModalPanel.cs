using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class EventButtonDetails
{
    public string buttonTitle;
    public Sprite buttonBackground;
    public UnityAction action;
}

public class ModalPanelDetails
{
    public string title;
    public string text;
    public Sprite iconImage;
    public Sprite panelBackgroundImage;
    public EventButtonDetails button1Details;
    public EventButtonDetails button2Details;
    public EventButtonDetails button3Details;
	public EventButtonDetails button4Details;

}

public class ModalPanel : MonoBehaviour
{
    public Text title;
    public Text text;
    public float letterPause = 0.2f;
    public Image iconImage;
    public Button button1;
    public Button button2;
    public Button button3;
	public Button button4;

    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
	public Text button4Text;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }

    public void NewChoice(ModalPanelDetails details)
    {
        modalPanelObject.SetActive(true);

        this.iconImage.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
		button4.gameObject.SetActive (false);

        title.text = "";
        text.text = "";

        title.text = details.title;
        StartCoroutine(TypeText(details.text));

        if (details.iconImage)
        {
            this.iconImage.sprite = details.iconImage;
            this.iconImage.gameObject.SetActive(true);
        }

		if (details.button1Details != null) 
		{
			button1.onClick.RemoveAllListeners ();
			button1.onClick.AddListener (details.button1Details.action);
			button1.onClick.AddListener (ClosePanel);
			button1Text.text = details.button1Details.buttonTitle;
			button1.gameObject.SetActive (true);
		}

        if (details.button2Details != null)
        {
            button2.onClick.RemoveAllListeners();
            button2.onClick.AddListener(details.button2Details.action);
            button2.onClick.AddListener(ClosePanel);
            button2Text.text = details.button2Details.buttonTitle;
            button2.gameObject.SetActive(true);
        }

        if (details.button3Details != null)
        {
            button3.onClick.RemoveAllListeners();
            button3.onClick.AddListener(details.button3Details.action);
            button3.onClick.AddListener(ClosePanel);
            button3Text.text = details.button3Details.buttonTitle;
            button3.gameObject.SetActive(true);
        }

		if (details.button4Details != null) 
		{
			button4.onClick.RemoveAllListeners();
			button4.onClick.AddListener(details.button4Details.action);
			button4.onClick.AddListener(ClosePanel);
			button4Text.text = details.button4Details.buttonTitle;
			button4.gameObject.SetActive(true);
		}
    }

    public void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }

    private IEnumerator TypeText(string message)
    {
        foreach (char letter in message.ToCharArray())
        {
			if (modalPanelObject.activeInHierarchy) {
				text.text += letter;
				yield return 0;
				yield return new WaitForSeconds (letterPause);
			} else {
				break;
			}
        }
    }
}