using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EconomyMaster : MonoBehaviour {

	public int startSteins;
	public int currentSteins;
	public List<GameObject> allParts;

	public GameObject hullPart;
	public GameObject machinePart;
	public GameObject lazerPart;
	public GameObject shotPart;
	public GameObject missilePart;
	public GameObject plasmaPart;

	public int hullPrice;
	public int machinePrice;
	public int lazerPrice;
	public int shotPrice;
	public int missilePrice;
	public int plasmaPrice;
	public int cratePrice;

	public GameObject currentPlayer;
	public List<GameObject> currentList;
	GameObject player01;
	GameObject player02;
	GameObject playerTitle;
	GameObject canvas;
	GameObject restartButton;



	// Use this for initialization
	void Start () {
		allParts = new List<GameObject> ();
		allParts.Add (hullPart);
		allParts.Add (machinePart);
		allParts.Add (lazerPart);
		allParts.Add (shotPart);
		allParts.Add (missilePart);
		allParts.Add (plasmaPart);
		currentSteins = startSteins;
		playerTitle = GameObject.FindGameObjectWithTag ("PlayerTitle");
		player01 = GameObject.FindGameObjectWithTag ("Player01");
		player02 = GameObject.FindGameObjectWithTag ("Player02");
		canvas = GameObject.FindGameObjectWithTag ("Canvas");
		currentPlayer = player01;
		DontDestroyOnLoad (transform.gameObject);
		DontDestroyOnLoad (canvas);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "MarketPhase" || Application.loadedLevelName == "BuildingPhase") {
			playerTitle.GetComponentInChildren<Text> ().text = "" + currentPlayer;
			currentList = currentPlayer.GetComponent<Inventory> ().invParts;
		}
	}

	public void Continue(){
		if (Application.loadedLevelName == "MarketPhase") {
			if (currentPlayer == player01) {
				currentPlayer = player02;
				currentSteins = startSteins;
			} else {
				StartCoroutine (LevelLoadBuild ());
			}
		} else {
			if (currentPlayer == player01) {
				currentPlayer = player02;
				player01.transform.GetChild(0).gameObject.SetActive(false);
				gameObject.GetComponent<SpawnParts> ().SpawnInitialParts();
			}
			else{
				player01.transform.GetChild(0).gameObject.SetActive(true);
				StartCoroutine(LevelLoadBattle());
			}
		}
	}

	IEnumerator LevelLoadBuild(){
		Application.LoadLevel("BuildingPhase");
		yield return new WaitForSeconds(0.05f);
		currentPlayer = player01;
		currentList = player01.GetComponent<Inventory> ().invParts;
		gameObject.GetComponent<SpawnParts> ().enabled = true;
		gameObject.GetComponent<DragObject> ().enabled = true;
		playerTitle.transform.localPosition += Vector3.down * 180.0f;
	}

	IEnumerator LevelLoadBattle(){
		Destroy (canvas);
		Application.LoadLevel("BattlePhase");
		gameObject.GetComponent<SpawnParts> ().SpawnBattleShips ();
		gameObject.GetComponent<ShipMovement> ().enabled = true;
		yield return new WaitForSeconds(0.5f);
		currentPlayer = player01;
	}
}
