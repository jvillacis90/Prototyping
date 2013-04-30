using UnityEngine;
using System.Collections;

public class EnemyDroneBehaviourScript : EnemyBaseClass 
{
	public GameObject projectile;
	public GameObject shotLocatorObj;
	public GameObject dParticle;
	int state = 4;
	int forward_state = 0;
	int backward_state = 1;
	int left_state = 2;
	int right_state = 3;
		
	GameObject player;
	float distance;
	
	bool generateState = true;
	bool returnToOriginal = false;
	float stateTimer = 0.0f;
	
	Vector3 originalPosition;

	public float travelDistance;
	
	public float speed;
	float targetY = 1;
	float turnSpeed = 1;
	float attackTimer;
	float attackTimerMax;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		originalPosition = this.transform.position;
		state = genState();
		SetDeathParticle(dParticle);
		attackTimerMax = Random.Range(2,5);
	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector3.Distance(this.transform.position, player.transform.position);
		if(distance < 100)
		{
		//rotation stuff
		Quaternion newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
    	newRotation.x = 0.0f;
    	newRotation.z = 0.0f;
    	transform.rotation = Quaternion.Slerp(newRotation,transform.rotation, Time.deltaTime * turnSpeed);
		
		//animation play
		animation.Play("Take 001");
		
		
		

			//movemment stuff
			if(state == forward_state)
			{
				transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, originalPosition.y + targetY, (speed/3) * Time.deltaTime), Mathf.MoveTowards(transform.position.z, originalPosition.z - travelDistance, speed * Time.deltaTime));	
				if(transform.position.z == originalPosition.z - travelDistance)
				{
					state = genState();
					targetY = genHeight(targetY);
				}
			}
			else if(state == backward_state)
			{
				transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, originalPosition.y + targetY, (speed/3) * Time.deltaTime), Mathf.MoveTowards(transform.position.z, originalPosition.z + travelDistance, speed * Time.deltaTime));	
				float what = originalPosition.z + travelDistance;
				float that = transform.position.z;
				if(what == that)
				{
					state = genState();
					targetY = genHeight(targetY);
				}
			}
			else if(state == right_state)
			{
				transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, originalPosition.x + travelDistance, speed * Time.deltaTime), Mathf.MoveTowards(transform.position.y, originalPosition.y + targetY, (speed/3) * Time.deltaTime), transform.position.z);
				float what = originalPosition.x + travelDistance;
				float that = transform.position.x;
				if(what == that)
				{
					state = genState();
					targetY = genHeight(targetY);
				}
			}
			else if(state == left_state)
			{
				transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, originalPosition.x - travelDistance, speed * Time.deltaTime), Mathf.MoveTowards(transform.position.y, originalPosition.y + targetY, (speed/3) * Time.deltaTime), transform.position.z);	
				if(transform.position.x == originalPosition.x - travelDistance)
				{
					state = genState();
					targetY = genHeight(targetY);
				}
			}
		}
		if (distance < 30)
		{
			//attack stuff
			attackTimer += Time.deltaTime;
			if(attackTimer > attackTimerMax)
			{
				GameObject proj = Instantiate(projectile, shotLocatorObj.transform.position, Quaternion.identity) as GameObject;
				proj.GetComponent<ProjectileMovementScript>().setDirection(shotLocatorObj.transform.position, player.transform.position);
				attackTimer = 0;
			}
		}
			
	}
	
	void OnTriggerEnter(Collider other) {
		DestroyObject(this.gameObject);
    }
	
	int genState()
	{
		bool go = true;
		int newState = -1;
		while (go)
		{
			newState = Random.Range(0,4);
			if(newState != state)
				go = false;
		}
		return newState;
	}
	float genHeight(float target)
	{
		return target *= -1;
	}
}
