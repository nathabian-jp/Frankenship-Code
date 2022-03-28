using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonSending : MonoBehaviour {

	Text priceTag;
	GameObject steinCounter;
	Text steinCounterText;
	GameObject canvas;
	GameObject master;
	EconomyMaster econScript;
	List<GameObject> currentList;
	public int myPrice;
	public GameObject myPart;
	AudioSource selectAudio;
	AudioClipHolder selectScript;

	// Use this for initialization
	void Start () {
		priceTag = gameObject.GetComponentInChildren<Text> ();
		steinCounter = GameObject.FindGameObjectWithTag ("SteinsCounterText");
		steinCounterText = steinCounter.GetComponent<Text> ();
		master = GameObject.FindGameObjectWithTag ("Master");
		econScript = master.GetComponent<EconomyMaster> ();
		selectAudio = GameObject.FindGameObjectWithTag ("MenuSelectAudio").GetComponent<AudioSource>();
		selectScript = GameObject.FindGameObjectWithTag ("MenuSelectAudio").GetComponent<AudioClipHolder> ();
		if (gameObject.tag == "Hull") {
			myPart = econScript.hullPart;
			myPrice = econScript.hullPrice;
		}
		if (gameObject.tag == "MachineGun") {
			myPart = econScript.machinePart;
			myPrice = econScript.machinePrice;
		}
		if (gameObject.tag == "LazerGun") {
			myPart = econScript.lazerPart;
			myPrice = econScript.lazerPrice;
		}
		if (gameObject.tag == "ShotGun") {
			myPart = econScript.shotPart;
			myPrice = econScript.shotPrice;;
		}
		if (gameObject.tag == "MissileLauncher") {
			myPart = econScript.missilePart;
			myPrice = econScript.missilePrice;
		}
		if (gameObject.tag == "PlasmaTorch") {
			myPart = econScript.plasmaPart;
			myPrice = econScript.plasmaPrice;;
		}
		if (gameObject.tag == "Crate") {
			myPrice = econScript.cratePrice;
		}
		priceTag.text = gameObject.tag + ": " + myPrice;

	}
	
	// Update is called once per frame
	void Update () {
		steinCounterText.text = "" + econScript.currentSteins;
	}

	public void BuyPart(){
		if (econScript.currentSteins >= myPrice) {
			econScript.currentSteins -= myPrice;
			AddToInventory ();
			selectAudio.clip = selectScript.selectOkay;
			selectAudio.Play ();
		} else {
			selectAudio.clip = selectScript.selectError;
			selectAudio.Play();
		}
	}

	public void AddToInventory(){
		if (gameObject.tag == "Crate") {
			myPart = econScript.allParts [Random.Range (0, econScript.allParts.Count)];
		}
		econScript.currentPlayer.GetComponent<Inventory>().invParts.Add(myPart);
	}
}
