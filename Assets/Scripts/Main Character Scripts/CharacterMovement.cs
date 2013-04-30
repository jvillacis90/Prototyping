using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public float moveSpeed = 1;
	public float jumpSpeed;
	public float gravity;
	
	PlayerAttributes playerA;
	
	//movement state variables
	public bool jumping;
	float jumpTimer = 0;
	
	public CharacterController controller;
	// Use this for initialization
	void Start () {
		controller = this.GetComponent<CharacterController>();
		playerA = PlayerAttributes.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 targetDirection = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;
	    Vector3 movement = targetDirection * moveSpeed;
		if(Input.GetButtonDown("Jump")&& controller.isGrounded)
		{
			jumping = true;
		}
		if(Input.GetButtonUp("Jump"))
		{
			jumping = false;
			jumpTimer = 0;
		}
		if(jumping)
		{
			if(jumpTimer <.1f)
				movement += new Vector3(0,jumpSpeed,0);
			jumpTimer+=Time.deltaTime;
			
		}
		else
		{
			movement -= new Vector3(0,gravity,0);
		}
	    movement *= Time.deltaTime;
	    controller.Move(movement);
	}
	
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.name);
    }
	
	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "DamageDealer")
		{
			playerA.takeDamage();
		}
    }
}