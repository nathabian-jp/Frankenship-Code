using UnityEngine;
using System.Collections;

public class CheckConnection : MonoBehaviour {

	GameObject master;
	DragObject dragScript;
	Transform connectPoint;
	CheckConnection connectScript;
	SpriteRenderer connectSprite;
	SpriteRenderer dadSprite;
	public bool connect;
	public bool connected;
	public float degrees;
	AudioSource mySounds;

	// Use this for initialization
	void Start () {
		master = GameObject.FindGameObjectWithTag ("Master");
		dragScript = master.GetComponent<DragObject> ();
		dadSprite = transform.parent.GetComponent<SpriteRenderer> ();
		mySounds = GameObject.FindGameObjectWithTag ("BuildSounds").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0) && dragScript.currentDrag == null && dragScript.lastDrag == transform.parent.gameObject) {
			dadSprite.material.color = Color.white;
		}

		if (dragScript.currentDrag == transform.parent.gameObject) {
			transform.parent.transform.SetParent (null);
			connected = false;
			if (gameObject.transform.parent.GetComponent<DistanceJoint2D> () != null 
			    && connectScript != null
			    && connectScript.transform.parent.gameObject == transform.parent.GetComponent<DistanceJoint2D> ().connectedBody.gameObject) {
				connectScript.connected = false;
			}

			if (connect == true && connected == false && connectScript.connected == false && dragScript.hitColl2) {
				print ("POPO");
				dadSprite.material.color = Color.green;
			}
		}


		if (connect) {
			if (connectScript.connected == false && connected == false && dragScript.hitColl2 != null){
				print ("ASDAS");
				if (dragScript.currentDrag == null &&  dragScript.lastDrag == transform.parent.transform.gameObject && transform.parent.GetComponent<DistanceJoint2D> () == null) {

					transform.parent.transform.position = 
						new Vector3(connectPoint.position.x, connectPoint.position.y, transform.parent.transform.position.z) + connectPoint.localPosition ;
					DistanceJoint2D newJoint = gameObject.transform.parent.gameObject.AddComponent<DistanceJoint2D>();
					newJoint.enableCollision = true;
					transform.parent.transform.SetParent (connectPoint.parent.transform);
					newJoint.connectedBody = transform.parent.transform.parent.GetComponent<Rigidbody2D>();
					newJoint.distance = 2.0f;
					connected = true;
					connectScript.connected = true;
					mySounds.Play();
					mySounds.pitch = Random.Range(0.7f, 1.2f);
					if(dadSprite.sortingLayerName == "Weapons"){
						newJoint.distance = 1.0f;
						Vector3 dir = transform.parent.transform.position - connectPoint.transform.parent.position;
						var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
						if(dadSprite.sortingOrder < 5){
							degrees = angle - 90;
							dragScript.limitRot = false;
						}
						if(dadSprite.sortingOrder == 5){
							print("dfasedawd");
							degrees = angle - 180;
							dragScript.limitRot = true;
						}
						transform.parent.transform.rotation = Quaternion.AngleAxis(degrees, Vector3.forward);
						dragScript.rotateMode = true;
					}
					if(connectPoint.tag == "CenterTrig" && transform.parent.GetComponent<SpriteRenderer>().sortingLayerName != "Hulls"){
						dragScript.rotateCenter = true;
						newJoint.distance = 0.0f;
					}
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (gameObject.tag == "Connection" || gameObject.tag == "CenterTrig") {
			connectPoint = other.transform;
			connectScript = other.GetComponent<CheckConnection> ();
			connectSprite = other.transform.parent.GetComponent<SpriteRenderer> ();
			if (connectSprite.sortingLayerName == "Hulls") {
				if (connectScript.connected == false) {
					connect = true;
				} else if (Application.loadedLevelName == "BuildingPhase") {
					dadSprite.material.color = Color.red;
				}
				if (gameObject.tag == "CenterTrig" && transform.parent.GetComponent<SpriteRenderer> ().sortingLayerName == "Hulls") {
					connect = false;
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (gameObject.tag == "Connection") {
			connectScript = other.GetComponent<CheckConnection> ();
			if (transform.parent.GetComponent<DistanceJoint2D> () != null 
				&& transform.parent.GetComponent<DistanceJoint2D> ().connectedBody == other.transform.parent.GetComponent<Rigidbody2D> ()) {
				connected = true;
				connectScript.connected = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		print ("Exit");
		connect = false;
		dadSprite.material.color = Color.white;
		if (gameObject.tag == "GridTrig") {
			Destroy(transform.parent.GetComponent<DistanceJoint2D>());
			transform.parent.SetParent(null);
		}
	}
}
