using UnityEngine;
using System.Collections;

public class AttackSpeed : MonoBehaviour {


    public float timeLimit;
    public float powerTimer = 5f;
	public float attack = 2f;
    private bool attackBuff = false;
    public ShootShoot shoot;

    // Use this for initialization
    void Start () {
        shoot = GetComponentInChildren<ShootShoot>();
        timeLimit = 0f;


    }
	
	// Update is called once per frame
	void Update () {
        //place where buff occurs
        if (attackBuff)
        {
            shoot.spawnSpeed = shoot.spawnSpeed / attack;  
        }
        else
        {
            shoot.spawnSpeed = shoot.spawnSpeed * attack;
        }
        //timer for attackbuff 
        if (timeLimit >= powerTimer)
        {
                attackBuff = false;
        }
        else
        {
            timeLimit += Time.deltaTime;
        }

	}
    //collides with powerup and triggers attackBuff bool
    void OnTriggerEnter2D (Collider2D other)
    {

     if (other.gameObject.tag == "PowerUp")
        {
            timeLimit = 0f;
            attackBuff = true;
            Destroy(other.gameObject);
        }
        

    }

}
