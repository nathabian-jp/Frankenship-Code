using UnityEngine;
using System.Collections;

public class BumpCheck : MonoBehaviour {

	GameObject master;
	DragObject dragScript;

	// Use this for initialization
	void Start () {
		master = GameObject.FindGameObjectWithTag ("Master");
		dragScript = master.GetComponent<DragObject> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other){
		dragScript.areaClear = false;
	}

	void OnTriggerExit2D(Collider2D other){
		dragScript.areaClear = true;
	}
}
