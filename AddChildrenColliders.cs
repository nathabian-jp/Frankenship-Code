using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddChildrenColliders : MonoBehaviour {

	Component[] allColls;
	List<Component> allHulls;

	// Use this for initialization
	void Start () {
		allHulls = new List<Component> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddMyChildColls(){
		allColls = gameObject.GetComponentsInChildren<BoxCollider2D> ();
		for (int i = 0; i < allColls.Length; i++){
			if(allColls[i].gameObject.GetComponent<SpriteRenderer>() != null && allColls[i].gameObject.GetComponent<SpriteRenderer>().sortingLayerName == "Hulls"){
				allHulls.Add(allColls[i]);
			}
		}
		for (int x = 0; x < allHulls.Count; x++){
			BoxCollider2D newColl = allHulls[x].GetComponent<BoxCollider2D>();
			BoxCollider2D myColl = gameObject.AddComponent<BoxCollider2D>();
			myColl.size = newColl.size;
			myColl.offset = new Vector2(newColl.transform.localPosition.x, newColl.transform.localPosition.y);
		}
	}
}
