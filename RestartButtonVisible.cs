using UnityEngine;
using System.Collections;

public class RestartButtonVisible : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	GameObject restartButton;

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag ("Player01");
		player2 = GameObject.FindGameObjectWithTag ("Player02");
		restartButton = GameObject.FindGameObjectWithTag ("RestartButton");
		restartButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (player1.transform.GetChild(0).gameObject.activeSelf == false || player2.transform.GetChild(0).gameObject.activeSelf == false) {
			restartButton.SetActive(true);
		}
	}
}
