using UnityEngine;
using System.Collections;

public class ProjectileMovementScript : MonoBehaviour {
	public float speed;
	Vector3 direction;
	float deathTimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		deathTimer+= Time.deltaTime;
		if(deathTimer > 1)
			Destroy(this.gameObject);
	}
	
	public void setDirection(Vector3 start, Vector3 end)
	{
		direction = end - start;
		direction = Vector3.Normalize(direction);
		this.rigidbody.AddForce(direction * speed);
	}
	
	void OnCollisionEnter(Collision collision) {
        Debug.Log("Here in collision enter on bullet");
		if(collision.gameObject.tag == "Enemy")
			Destroy(collision.gameObject);
		Destroy(this.gameObject);
    }
}
