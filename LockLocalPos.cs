using UnityEngine;
using System.Collections;

public class LockLocalPos : MonoBehaviour {

	GameObject master;
	DragObject dragScript;
	public Vector3 myLocPos;
	public Quaternion myLocRot; 

	// Use this for initialization
	void Start () {
		master = GameObject.FindGameObjectWithTag ("Master");
		dragScript = master.GetComponent<DragObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (dragScript.battlePhase == false) {
			myLocPos = transform.localPosition;
			myLocRot = transform.localRotation;
		} else {
			transform.localPosition = myLocPos;
			transform.localRotation = myLocRot;
		}
	}
}
