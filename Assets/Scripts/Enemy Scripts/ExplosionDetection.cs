using UnityEngine;
using System.Collections;

public class ExplosionDetection : MonoBehaviour {
	Vector3 direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setDirection(Vector3 start, Vector3 end)
	{
		direction = end - start;
		direction = Vector3.Normalize(direction);
		this.rigidbody.AddForce(direction * 8000);
	}
}
