using UnityEngine;
using System.Collections;

public class EnemyBehaviourLittle : MonoBehaviour {
	GameObject mainPlayerTarget;
	public float force;
	public float maxSpeed;
	Vector3 direction;

	// Use this for initialization
	void Start () {
		mainPlayerTarget = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		 if (rigidbody.SweepTest(transform.forward, out hit, sweepDistance))
		{
            //Debug.Log(hit.distance + "mts distance to obstacle");
			//Debug.Log(hit.collider.gameObject);
			
			
		}
		
		//transform.Translate(direction);
		
		//transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, mainPlayerTarget.transform.position.x, speed * Time.deltaTime), transform.position.y, Mathf.MoveTowards(transform.position.z, mainPlayerTarget.transform.position.z, speed * Time.deltaTime));
	
	}
	
	void FixedUpdate()
	{
		Debug.Log(this.rigidbody.velocity);
		direction = mainPlayerTarget.transform.position - this.transform.position;
		if(direction.magnitude > 5  && direction.magnitude < 30)
		{
			direction = Vector3.Normalize(direction);
			direction.y = 0;
			this.rigidbody.AddForce(direction * force);
			rigidbody.velocity = maxSpeed * (rigidbody.velocity.normalized);
			//this.rigidbody.velocity = 4;
			//this.rigidbody.
		}
	}
	
}
