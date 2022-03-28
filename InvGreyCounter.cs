using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InvGreyCounter : MonoBehaviour {

	GameObject master;
	EconomyMaster econScript;
	Text myPartCount;
	Image greyImage;
	private int myInvCount = 0;
	public int prevInvCount;
	public GameObject prevPlayer;
	public GameObject myInvPart;
	Inventory invScript;
	Button myButton;
	DragObject dragScript;


	// Use this for initialization
	void Start () {
		master = GameObject.FindGameObjectWithTag ("Master");
		econScript = master.GetComponent<EconomyMaster> ();
		dragScript = master.GetComponent<DragObject> ();
		myPartCount = gameObject.GetComponentInChildren<Text> ();
		myButton = gameObject.GetComponent<Button> ();
		greyImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (dragScript.enabled == true) {
			myButton.enabled = true;
		}

		myInvCount = 0;
		for (int i = 0; i < econScript.currentList.Count; i++) {
			if(econScript.currentList[i].tag == gameObject.tag){
				myInvCount += 1;
			}
		}

		if (myInvCount == 0) {
			greyImage.color = Color.white;
		} else {
			greyImage.color = new Color (1.0f, 1.0f, 1.0f, 0.2f - 0.1f * myInvCount);
		}
		myPartCount.text = "X " + myInvCount;
		prevInvCount = econScript.currentList.Count;
		prevPlayer = econScript.currentPlayer;
	}

	public void SpawnPart(){
		if (myInvCount > 0) {
			for (int i = 0; i < econScript.currentList.Count; i++) {
				if(econScript.currentList[i].tag == gameObject.tag){
					myInvPart = econScript.currentList[i];
					econScript.currentPlayer.GetComponent<Inventory>().invParts.Remove(myInvPart);
				}
			}
			Instantiate(myInvPart, dragScript.mPos + Vector3.left * 2.0f, transform.rotation);
		}
	}
}
