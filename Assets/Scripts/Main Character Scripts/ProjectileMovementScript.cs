using UnityEngine;
using System.Collections;

public class ProjectileMovementScript : MonoBehaviour {
	public float speed;
	Vector3 direction;
	float deathTimer;
	PlayerAttributes playerA;
	// Use this for initialization
	void Start () {
		playerA = PlayerAttributes.GetInstance();
	}
	
	// Update is called once per frame
	
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
		if(collision.gameObject.tag == "Player")
		{
			playerA.takeDamage();
		}
		Destroy(this.gameObject);
    }
}
