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
		if(collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.GetComponent<EnemyBaseClass>().ShowDeath();
			if(collision.gameObject.name == "Enemy_Little")
				collision.gameObject.GetComponent<EnemyBehaviourLittle>().shootCollisionBodies();
			Destroy(collision.gameObject);
		}
		Destroy(this.gameObject);
    }
}
