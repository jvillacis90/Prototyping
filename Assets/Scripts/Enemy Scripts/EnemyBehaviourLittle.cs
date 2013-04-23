using UnityEngine;
using System.Collections;

public class EnemyBehaviourLittle : EnemyBaseClass {
	GameObject mainPlayerTarget;
	public float force;
	public float maxSpeed;
	Vector3 direction;
	
	public GameObject explosion;
	public GameObject dParticle;
	bool keepTracking = true;
	
	float turnSpeed = 1;
	// Use this for initialization
	
	float finalPosY;
	
	public GameObject explosionDetectionObject;
	
	public GameObject test;
	void Start () {
		mainPlayerTarget = GameObject.FindGameObjectWithTag("Player");
		SetDeathParticle(dParticle);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//transform.Translate(direction);
		
		//transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, mainPlayerTarget.transform.position.x, speed * Time.deltaTime), transform.position.y, Mathf.MoveTowards(transform.position.z, mainPlayerTarget.transform.position.z, speed * Time.deltaTime));
		if(keepTracking)
		{
			Quaternion newRotation = Quaternion.LookRotation(transform.position - mainPlayerTarget.transform.position, Vector3.forward);
	    	newRotation.x = 0.0f;
	    	newRotation.z = 0.0f;
	    	transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * turnSpeed);
			direction = mainPlayerTarget.transform.position - this.transform.position;
			if(direction.magnitude > 3  && direction.magnitude < 30)
			{
				if(direction.magnitude < 8)
				{
					finalPosY = this.gameObject.transform.position.y;
					keepTracking = false;
					rigidbody.useGravity = false;
				}
				direction = Vector3.Normalize(direction);
				direction.y = 0;
				this.rigidbody.AddForce(direction * force);
				rigidbody.velocity = maxSpeed * (rigidbody.velocity.normalized);
				turnSpeed = 5;
				
			}
		}
		else
		{
			this.rigidbody.AddForce(0,5,0);
			
			if(this.transform.position.y - finalPosY > 1)
			{
				DestroyObject(this.gameObject);
				Instantiate(explosion, this.transform.position, Quaternion.identity);
				shootCollisionBodies();
			}
		}
		
	}
	
	public void shootCollisionBodies()
	{
		GameObject sphere = Instantiate(explosionDetectionObject,this.transform.position, Quaternion.identity) as GameObject;
		sphere.GetComponent<ExplosionDetection>().setDirection(this.transform.position, this.transform.position + new Vector3(1,0,0));
		
		sphere = Instantiate(explosionDetectionObject,this.transform.position, Quaternion.identity) as GameObject;
		sphere.GetComponent<ExplosionDetection>().setDirection(this.transform.position, this.transform.position + new Vector3(-1,0,0));
		
		sphere = Instantiate(explosionDetectionObject,this.transform.position, Quaternion.identity) as GameObject;
		sphere.GetComponent<ExplosionDetection>().setDirection(this.transform.position, this.transform.position + new Vector3(0,0,1));
		
		sphere = Instantiate(explosionDetectionObject,this.transform.position, Quaternion.identity) as GameObject;
		sphere.GetComponent<ExplosionDetection>().setDirection(this.transform.position, this.transform.position + new Vector3(0,0,-1));
	}
	
	void OnTriggerEnter(Collider other) {
		DestroyObject(this.gameObject);
		Instantiate(explosion, this.transform.position, Quaternion.identity);
		shootCollisionBodies();
    }

	/*
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.name);
    }
	
	void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
    }
    */
	//void ShowDeath
}
