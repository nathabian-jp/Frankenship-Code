using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTextColorFade : MonoBehaviour {

	Text mytext;
	Color myStartColor;
	public float increment;

	// Use this for initialization
	void Start () {
		mytext = gameObject.GetComponent<Text> ();
		myStartColor = mytext.color;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void BlackToColorFade(){
		mytext.color = Color.black;
		mytext.color = Color.Lerp (Color.black, myStartColor, increment);
		if (mytext.color != myStartColor) {
			StartCoroutine (LerpWait ());
		}
	}

	IEnumerator LerpWait(){
		yield return new WaitForSeconds (0.075f);
		increment += 0.1f;
		BlackToColorFade ();
	}
}
