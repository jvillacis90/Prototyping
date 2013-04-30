using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	GameObject target;
	
	float distance;
	/*
	void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + (transform.forward * distance));
    }
	*/
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(target.transform.position, this.transform.position);
		RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position,transform.forward,distance);
		foreach(RaycastHit bam in hits)
		{
			bam.collider.renderer.enabled = false;
		}
	}
}
