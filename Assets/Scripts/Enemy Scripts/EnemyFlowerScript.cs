using UnityEngine;
using System.Collections;

public class EnemyFlowerScript : EnemyBaseClass {
	float distance;
	GameObject player;
	float attackTimer = 2;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(this.transform.position, player.transform.position);
		if(distance < 75)
		{
			if(distance < 20)
			{
				attackTimer+=Time.deltaTime;
				if(attackTimer < 2 && !animation.IsPlaying("Take 002"))
					animation.CrossFade("Take 001");
				if(attackTimer > 2)
				{
					animation.CrossFade("Take 002");
					attackTimer = 0;
				}
			}
		}	
	}
}
