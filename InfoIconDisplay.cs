using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoIconDisplay : MonoBehaviour {

	private int clickNumber;
	private GameObject infoBox;
	private Text infoText;
	public string myInfo;
	AudioSource mySource;
	// Use this for initialization
	void Start () {
		infoBox = GameObject.FindGameObjectWithTag ("InfoTextBox");
		infoText = infoBox.transform.GetChild(0).GetComponent<Text> ();

		mySource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (infoBox.activeSelf && infoText.text == myInfo) {
			clickNumber = 1;
		} else {
			clickNumber = 0;
		}
	}

	public void DisplayInfo(){
		if (clickNumber == 0) {
			infoBox.SetActive (true);
			infoText.text = myInfo;
			mySource.pitch = Random.Range(1.0f, 1.2f);
		} else {
			infoBox.SetActive (false);
			mySource.pitch = Random.Range(0.6f, 0.8f);
		}
	}
}
