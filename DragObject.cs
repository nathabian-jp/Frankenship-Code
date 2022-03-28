using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DragObject : MonoBehaviour {
	
	public GameObject currentDrag;
	public GameObject lastDrag;
	SpriteRenderer lastSprite;
	public Vector3 mPos;
	Collider2D hitColl;
	public Collider2D hitColl2;
	GameObject player1;
	GameObject player2;
	GameObject core;
	public bool rotateMode;
	public bool rotateCenter;
	public int weaponDir = 0;
	public bool areaClear = true;
	public bool limitRot;
	LayerMask dragLayer = 1 << 14;
	LayerMask gridLayer = 1 << 15;
	public bool playerChange;
	GameObject continueButton;
	GameObject battleButton;
	public bool battlePhase;


	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag ("Player01");
		player2 = GameObject.FindGameObjectWithTag ("Player02");
		core = GameObject.FindGameObjectWithTag ("Core");
		continueButton = GameObject.FindGameObjectWithTag ("ContinueButton");
		battleButton = GameObject.FindGameObjectWithTag ("BattleButton");
		DontDestroyOnLoad (player2);
	}
	
	// Update is called once per frame
	void Update () {
		core = GameObject.FindGameObjectWithTag ("Core");
		mPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mPos.z = -1;
		hitColl = Physics2D.OverlapPoint (new Vector2 (mPos.x, mPos.y), dragLayer);
		hitColl2 = Physics2D.OverlapPoint (new Vector2 (mPos.x, mPos.y), gridLayer);

		print (hitColl2);

		if (rotateMode == false && hitColl != null && hitColl.transform.parent.tag != "ShieldHull" && hitColl.transform.parent.tag != "Core") {
			if (Input.GetMouseButtonDown(0)){
				currentDrag = hitColl.gameObject.transform.parent.gameObject;
				Destroy (currentDrag.GetComponent<DistanceJoint2D> ());
				currentDrag.transform.SetParent(null);
				currentDrag.transform.eulerAngles = Vector3.zero;
			}
			if (Input.GetMouseButton(0) && currentDrag != null){
				currentDrag.transform.position = mPos;
			}
			if (Input.GetMouseButtonUp(0) && currentDrag != null){
				lastDrag = currentDrag;
				currentDrag = null;
			}
		}

		if (rotateMode) {
			lastSprite = lastDrag.GetComponent<SpriteRenderer>();
			print (lastSprite);
			if (rotateCenter){
				weaponDir = 0;
			}
			print (lastSprite.material.color);
			if(areaClear){
				lastSprite.material.color = Color.green;
				print (lastSprite.material.color);
			}
			else{
				lastSprite.material.color = Color.red;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow) && weaponDir > -2){
				if (limitRot == false || (limitRot == true && rotateCenter == true)){
					lastDrag.transform.eulerAngles = lastDrag.transform.eulerAngles + new Vector3 (0,0,45);
				}
				else {
					lastDrag.transform.eulerAngles = lastDrag.transform.eulerAngles + new Vector3 (0,0,180);
				}
				weaponDir -= 1;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow) && weaponDir < 2){
				if (limitRot == false || (limitRot == true && rotateCenter == true)){
					lastDrag.transform.eulerAngles = lastDrag.transform.eulerAngles + new Vector3 (0,0,-45);
				}
				else {
					lastDrag.transform.eulerAngles = lastDrag.transform.eulerAngles + new Vector3 (0,0,-180);
				}
				weaponDir += 1;
			}
			
			if ((Input.GetKeyDown(KeyCode.Return) && areaClear) || Input.GetMouseButtonDown(1)) {
				rotateMode = false;
				rotateCenter = false;
				lastSprite.material.color = Color.white;
				weaponDir = 0;
			}
		}
	}
}
