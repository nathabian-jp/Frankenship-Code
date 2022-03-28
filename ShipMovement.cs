using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	public float zTurn;
	public float speed;

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag ("Player01");
		player2 = GameObject.FindGameObjectWithTag ("Player02");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("KeyboardHorizontalP1") != 0) {
			player1.transform.eulerAngles = player1.transform.eulerAngles - new Vector3(0,0, zTurn * Input.GetAxis("KeyboardHorizontalP1"));
		}
		if (Input.GetAxis ("KeyboardHorizontalP2") != 0) {
			player2.transform.eulerAngles = player2.transform.eulerAngles - new Vector3(0,0, zTurn * Input.GetAxis("KeyboardHorizontalP2"));
		}
		if (Input.GetAxis ("KeyboardVerticalP1") != 0) {
			player1.transform.Translate(Vector3.up * Input.GetAxis("KeyboardVerticalP1") * speed);
		}
		if (Input.GetAxis ("KeyboardVerticalP2") != 0) {
			player2.transform.Translate(Vector3.up * Input.GetAxis("KeyboardVerticalP2") * speed);
		}
	}
}
