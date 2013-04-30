using UnityEngine;
using System.Collections;

public class EnemyDroneBehaviourScript : MonoBehaviour 
{
	/*
	int state = 4;
	int forward_state = 0;
	int backward_state = 1;
	int left_state = 2;
	int right_state = 3;
	
	public float force;
	
	GameObject player;
	float distance;
	
	bool generateState = true;
	
	float stateTimer = 0.0f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		animation.Play("Take 001");
		distance = Vector3.Distance(this.transform.position, player.transform.position);
		if(distance < 10)
		{
			if(generateState)
			{
				state = Random.Range(0,4);
				generateState = false;
			}
			if(state == forward_state)
			      this.rigidbody.AddForce(transform.forward * force);
			else if(state == backward_state)
			      this.rigidbody.AddForce((transform.forward * -1) * force);
			else if(state == left_state)
			      this.rigidbody.AddForce((transform.right * -1) * force);
			else if(state == right_state)
			      this.rigidbody.AddForce(transform.right * force);
		}
				
	}
	*/
}
