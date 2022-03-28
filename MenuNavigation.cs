using UnityEngine;
using System.Collections;

public class MenuNavigation : MonoBehaviour {
	GameObject player1;
	GameObject player2;
	GameObject master;

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag ("Player01");
		player2 = GameObject.FindGameObjectWithTag ("Player02");
		master = GameObject.FindGameObjectWithTag ("Master");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadMarketPhase(){
		Application.LoadLevel ("MarketPhase");
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void RestartGame (){
		Destroy (player1);
		Destroy (player2);
		Destroy (master);
		Application.LoadLevel ("MainMenu");
	}
}
