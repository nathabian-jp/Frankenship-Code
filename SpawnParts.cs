using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnParts : MonoBehaviour {

	DragObject dragScript;
	EconomyMaster econScript;

	public bool playerChange;
	public float spawnXDist = 2.0f;
	public float spawnYDist = 5.0f;
	public int spawnXMax;
	public GameObject corePrefab;
	public GameObject shieldHullPrefab;
	GameObject player1;
	GameObject player2;
	public Vector3 startPos;
	public Vector3 spawnPos;

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag ("Player01");
		player2 = GameObject.FindGameObjectWithTag ("Player02");
		dragScript = gameObject.GetComponent<DragObject> ();
		econScript = gameObject.GetComponent<EconomyMaster> ();
		startPos = spawnPos;
		SpawnInitialParts ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SpawnInitialParts(){
		spawnPos = Vector3.zero;
		GameObject newCore = (GameObject) Instantiate(corePrefab, spawnPos, transform.rotation);
		newCore.transform.SetParent(econScript.currentPlayer.transform);
		Rigidbody2D coreBody = (Rigidbody2D) newCore.GetComponent<Rigidbody2D>();
		spawnPos = Vector3.left;

		for (int i = 0; i < 2; i++) {
			float myDist = 2.0f;
			GameObject newHull = (GameObject) Instantiate(shieldHullPrefab, spawnPos * myDist, transform.rotation);
			newHull.transform.SetParent (newCore.transform);
			DistanceJoint2D Joint01 = newHull.AddComponent<DistanceJoint2D>();
			Joint01.enableCollision = true;
			Joint01.connectedBody = coreBody;
			Joint01.distance = 2.0f;
			spawnPos = Vector3.right;
		}
	}

	public void SpawnBattleShips(){
		player1.transform.position += Vector3.left * spawnXDist;
		player2.transform.position += Vector3.right * spawnXDist;
	}
}
