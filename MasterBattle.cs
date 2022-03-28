using UnityEngine;
using System.Collections;

public class MasterBattle : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	public float spawnDist;
	GameObject restartButton;

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag ("Player1");
		player2 = GameObject.FindGameObjectWithTag ("Player2");
		restartButton = GameObject.FindGameObjectWithTag ("RestartButton");
		player1.transform.position = new Vector3 (-spawnDist, 0, 0);
		player2.transform.position = new Vector3 (spawnDist, 0, 0);
		player1.transform.eulerAngles = Vector3.zero;
		player2.transform.eulerAngles = Vector3.zero;
		restartButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (player1.gameObject == null || player2.gameObject == null) {
			restartButton.SetActive(true);
		}
	}

	public void RestartGame(){
		Application.LoadLevel ("MainMenu");
	}
}
