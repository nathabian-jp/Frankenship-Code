using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryKeeper : MonoBehaviour {

	public List<GameObject> invPartsP1;
	public List<GameObject> invPartsP2;


	// Use this for initialization
	void Start () {
		invPartsP1 = new List<GameObject> ();
		invPartsP2 = new List<GameObject> ();
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
