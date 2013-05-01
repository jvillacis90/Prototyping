using UnityEngine;
using System.Collections;

public class EnemyFlowerScript : EnemyBaseClass {
	float distance;
	GameObject player;
	int playState = 0;
	int shootState = 1;
	float attackTimer = 2;
	public GameObject projectile;
	public GameObject shotLocatorObj;
	public GameObject targetLocatorObj;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(this.transform.position, player.transform.position);
		if(distance < 30)
		{
			attackTimer+=Time.deltaTime;
			if(attackTimer < 2 && !animation.isPlaying && playState == 0)
			{
				animation.CrossFade("Take 001");
				
					
			}
			if(attackTimer > 2)
			{
				animation.CrossFade("Take 002");
				attackTimer = 0;
				playState = shootState;
			}
			if(playState == shootState && !animation.isPlaying)
			{
				Debug.Log("here in state");
				GameObject proj = Instantiate(projectile, shotLocatorObj.transform.position, Quaternion.identity) as GameObject;
				proj.GetComponent<ProjectileMovementScript>().setDirection(shotLocatorObj.transform.position, targetLocatorObj.transform.position);
				animation.Play("Take 003");
				playState = 0;
			}
		}
		else
		{
			animation.CrossFade("Take 001");		
		}
	}
}
