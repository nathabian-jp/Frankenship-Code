using UnityEngine;
using System.Collections;

public class RandAlterPitch : MonoBehaviour {

	AudioSource mySource;

	/// <summary>
	/// The current pitch of the AudioSource
	/// </summary>
	public float myPitch;

	/// <summary>
	/// The minimum variable.
	/// </summary>
	public float minVar;

	/// <summary>
	/// The max variable.
	/// </summary>
	public float maxVar;

	// Use this for initialization
	void Start () {
		mySource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		myPitch = mySource.pitch;
		if (mySource.isPlaying && mySource.time > (mySource.clip.length - 0.1)) {
			mySource.pitch = Random.Range(minVar,maxVar);
		}
	}
}
