using UnityEngine;
using System.Collections;

public class GenerateWall : MonoBehaviour {

    public GameObject wall;

    //setup for max and min values
    public float MinX = 0f;
    public float MinY = 0f;
    public float MaxX = 50f;
    public float MaxY = 50f;
    public float numberOfWalls = 10f;



    // Use this for initialization
    void Start () {
        //setup for random.range


        //loop for # of objects
        for (int j = 1;  j <= numberOfWalls; j++)
        {
            float x = Random.Range(MinX, MaxX);
            float y = Random.Range(MinY, MaxY);
            Instantiate(wall, new Vector3(x, y, 0), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

