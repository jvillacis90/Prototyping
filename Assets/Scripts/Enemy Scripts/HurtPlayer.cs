using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {
	public float growthRate;
	public GameObject targetPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<SphereCollider>().radius += Time.deltaTime * 3;
		/*
		RaycastHit hit;
        if (Physics.SphereCast(this.transform.position, 100, targetPlayer.transform.position - this.transform.position, out hit, Mathf.Infinity))
			//if(hit.collider.gameObject.tag == "Player")
            	Debug.Log(hit.collider.gameObject.name);
		
		RaycastHit[] arrayHit;
       	Physics.SphereCastAll(this.transform.position, 100, targetPlayer.transform.position - this.transform.position, out hit, Mathf.Infinity);
       	*/
	}
	
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.name);
		Debug.Log("In hurt PLayer");
    }
	
	void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
		Debug.Log("In hurt PLayer");
    }
}
