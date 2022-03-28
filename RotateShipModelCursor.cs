using UnityEngine;
using System.Collections;

public class RotateShipModelCursor : MonoBehaviour {
	

	void Update ()
	{
		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
