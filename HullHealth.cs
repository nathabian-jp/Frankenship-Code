using UnityEngine;
using System.Collections;

public class HullHealth : MonoBehaviour {

	public int startHealth;
	public int myHealth;
	ProjectileMovement projScript;
	SpriteRenderer mySprite;
	Material myMat;
	BoxCollider2D myColl;

	// Use this for initialization
	void Start () {
		myHealth = startHealth;
		mySprite = gameObject.GetComponent<SpriteRenderer> ();
		myMat = mySprite.material;
		myColl = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myHealth <= 0) {
			myMat.color = new Color(1.0f,1.0f,1.0f,0.5f);
			myColl.enabled = false;
			if(gameObject.tag == "Core"){
				gameObject.SetActive(false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		SpriteRenderer hisSprite = other.transform.GetComponent<SpriteRenderer> ();
		projScript = other.GetComponent<ProjectileMovement> ();
		if (hisSprite != null && hisSprite.sortingLayerName == "Projectiles") {
			myHealth -= projScript.bulletDamage;
			Destroy(other.gameObject);
		}
	}
}
