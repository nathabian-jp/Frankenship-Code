using UnityEngine;
using System.Collections;

public class ShootShoot : MonoBehaviour {

	public GameObject myBullet;
	public bool timeStarted;
	public float spawnSpeed;
	public float bulletSpeed;
	public int bulletDamage;
	GameObject battleStart;
	ProjectileMovement projScript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.tag = transform.root.tag;
		if (Application.loadedLevelName == "BattlePhase" && timeStarted == false) {
			StartCoroutine(ShotWait());
		}

	}

	public void FireShot(){
		if (transform.parent.tag == "LazerGun") {
			gameObject.transform.localPosition = new Vector3(-0.2f, transform.localPosition.y, 0);
			GameObject newLazer1 = (GameObject)Instantiate (myBullet, transform.position, transform.rotation);
			gameObject.transform.localPosition = new Vector3(+0.2f, transform.localPosition.y, 0);
			GameObject newLazer2 = (GameObject)Instantiate (myBullet, transform.position, transform.rotation);
			gameObject.transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
			projScript = newLazer1.GetComponent<ProjectileMovement> ();
			projScript.bulletSpeed = bulletSpeed;
			projScript.bulletDamage = bulletDamage;
			projScript = newLazer2.GetComponent<ProjectileMovement> ();
			projScript.bulletSpeed = bulletSpeed;
			projScript.bulletDamage = bulletDamage;
		} 
		else if (transform.parent.tag == "ShotGun") {
			gameObject.transform.localPosition = new Vector3(-0.5f, transform.localPosition.y, 0);
			gameObject.transform.eulerAngles = gameObject.transform.eulerAngles + new Vector3(0,0, 15);
			GameObject newShot1 = (GameObject)Instantiate (myBullet, transform.position, transform.rotation);
			gameObject.transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
			gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
			GameObject newShot2 = (GameObject)Instantiate (myBullet, transform.position, transform.rotation);
			gameObject.transform.localPosition = new Vector3(+0.5f, transform.localPosition.y, 0);
			gameObject.transform.eulerAngles = gameObject.transform.eulerAngles + new Vector3(0,0, -15);
			GameObject newShot3 = (GameObject)Instantiate (myBullet, transform.position, transform.rotation);
			gameObject.transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
			gameObject.transform.eulerAngles = new Vector3(0,0,0);
			projScript = newShot1.GetComponent<ProjectileMovement> ();
			projScript.bulletSpeed = bulletSpeed;
			projScript.bulletDamage = bulletDamage;
			projScript = newShot2.GetComponent<ProjectileMovement> ();
			projScript.bulletSpeed = bulletSpeed;
			projScript.bulletDamage = bulletDamage;
			projScript = newShot3.GetComponent<ProjectileMovement> ();
			projScript.bulletSpeed = bulletSpeed;
			projScript.bulletDamage = bulletDamage;
		}
		else {
			print("asdawd");
			GameObject newBullet = (GameObject)Instantiate (myBullet, transform.position, transform.rotation);
			projScript = newBullet.GetComponent<ProjectileMovement> ();
			projScript.bulletSpeed = bulletSpeed;
			projScript.bulletDamage = bulletDamage;
			if (transform.parent.tag == "PlasmaTorch") {
				newBullet.transform.SetParent (transform.parent.gameObject.transform);
			}
		}
	}

	IEnumerator ShotWait(){
		timeStarted = true;
		yield return new WaitForSeconds(spawnSpeed);
		FireShot ();
		timeStarted = false;
	}
}
