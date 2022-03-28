using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour
{

    GameObject playerOne;
    GameObject playerTwo;

    //current distance between ships
    float dist_between_ships = 0;
    //distance between ships in the previouse frame
    float prev_dist = 0;

    //maths
    float x_avg = 0, y_avg = 0, z_avg = 0;

	// Use this for initialization
	void Start ()
    {
		playerOne = GameObject.FindGameObjectWithTag ("Player01");
		playerTwo = GameObject.FindGameObjectWithTag ("Player02");
	}
	
	// Update is called once per frame
	void Update()
    {
        //distance between ships in the previous frame
        prev_dist = dist_between_ships;
        //current distance between ships
        dist_between_ships = Vector3.Distance(playerOne.transform.position, playerTwo.transform.position);
        //maths
        x_avg = (playerOne.transform.position.x + playerTwo.transform.position.x) / 2;
        y_avg = (playerOne.transform.position.y + playerTwo.transform.position.y) / 2;

        //move camera position to between the two ships
        Camera.main.transform.position = new Vector3(x_avg, y_avg, -10);

        //zoom the camera based on distance between ships
        if (dist_between_ships / 2 <= 10.0f)
        {
            Camera.main.orthographicSize = 10.0f;
        }
        else
        {
            Camera.main.orthographicSize = dist_between_ships / 2;
        }
    }

}
