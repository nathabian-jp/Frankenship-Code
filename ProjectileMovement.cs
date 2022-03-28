using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	public float bulletSpeed;
	public int bulletDamage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * bulletSpeed, Space.Self);
	}

	void OnTriggerEnter2D(Collider2D other){

	}
}
